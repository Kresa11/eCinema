using System.Security.Cryptography;
using AutoMapper;
using eCinema.Model.Dtos;
using eCinema.Model.Requests;
using eCinema.Model.SearchObjects;
using eCinema.Services.Database;
using eCinema.Services.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Trainers;

namespace eCinema.Services.Services
{
    public class MovieService : BaseCRUDService<MovieDto, Movie, MovieSearchObject, MovieUpsertRequest, MovieUpsertRequest>,
        IMovieService
    {
        public MovieService(CinemaContext cinemaContext, IMapper mapper) : base(cinemaContext, mapper)
        {
        }

        public override async Task<IEnumerable<MovieDto>> GetAll(MovieSearchObject? search = null)
        {
            if (search?.HasProjection is true && search.IsActive is true)
            {
                var list = await base.GetAll(search);
                var returnList = new List<MovieDto>();
                foreach (var movie in list)
                {
                    if (await _cinemaContext.Projections.AnyAsync(x => x.MovieId == movie.Id && movie.IsActive == true))
                        returnList.Add(movie);
                }
                return returnList;
            }
            return await base.GetAll(search);
        }

        public override IQueryable<Movie> AddFilter(IQueryable<Movie> query, MovieSearchObject search)
        {
            var filteredQuery = query;

            if(!string.IsNullOrWhiteSpace(search.Name))
                filteredQuery = filteredQuery.Where(x => x.Name!.ToLower().Contains(search.Name.ToLower()));

            if (!string.IsNullOrWhiteSpace(search.Director))
                filteredQuery = filteredQuery.Where(x => x.Director!.ToLower().Contains(search.Director.ToLower()));

            if (!string.IsNullOrWhiteSpace(search.Genres) && search.Genres!="Svi")
                filteredQuery = filteredQuery.Where(x => x.Genres!.ToLower().Contains(search.Genres.ToLower()));

            if (search?.IsActive is not null)
            {
                filteredQuery = filteredQuery.Where(x => x.IsActive == search.IsActive);
            }

            return filteredQuery;

        }

        public override void BeforeInsert(MovieUpsertRequest insert, Movie entity)
        {
            if (insert.Picture == null)
                entity.Picture = Images.DefaultImage;
        }

        public override void BeforeUpdate(Movie entity)
        {
            if (entity.Picture == null)
                entity.Picture = Images.DefaultImage;
        }

        public async override Task<MovieDto> Delete(Guid id)
        {
            var movie = await _cinemaContext.Movies.FindAsync(id);

            if (await _cinemaContext.Projections.AnyAsync(x => x.MovieId == id) == false)
            {
                return await base.Delete(id);
            }
            else
            {
                throw new Exception("This movie has active projections!");
            }
        }

        static object isLocked = new object();
        static MLContext mlContext = null;
        static ITransformer model = null;

        public async Task<List<MovieDto>> Recommend(Guid id)
        {
            lock (isLocked)
            {
                if (mlContext == null)
                {
                    mlContext = new MLContext();
                    // lista usera
                    var tmpData = _cinemaContext.Users?.Include(x => x.Reservations)?.ThenInclude(y => y.Projection).ToList();
                    List<MovieEntry> data = new List<MovieEntry>();

                    foreach (var x in tmpData)
                    {
                        var counterUser = 0;
                        if (x.Reservations.Count > 1)
                        {
                            if (x.Reservations.Any(x => x.Projection?.MovieId == id))
                            {
                                // movieId
                                var distinctItemId = x.Reservations.Select(y => y.Projection?.MovieId).ToList();

                                distinctItemId.ForEach(y =>
                                {
                                    var relatedItems = x.Reservations.Where(z => z.Projection?.MovieId != y);

                                    foreach (var z in relatedItems)
                                    {
                                        var movie = _cinemaContext.Movies.Find(y);
                                        data.Add(new MovieEntry()
                                        {
                                            MovieId = (uint)_cinemaContext.Movies.Local.ToList().IndexOf(movie),
                                            UserId = (uint) counterUser,
                                        });
                                    }

                                });

                                if (data == null || data.Count() < 3)
                                {
                                    var lastThree = _cinemaContext.Movies.AsEnumerable().TakeLast(3).ToList();
                                    return _mapper.Map<List<MovieDto>>(lastThree);
                                }
                            }
                            else
                            {
                                var lastThree = _cinemaContext.Movies.AsEnumerable().TakeLast(3).ToList();
                                return _mapper.Map<List<MovieDto>>(lastThree);
                            }
                        }
                        else
                        {
                            var lastThree = _cinemaContext.Movies.AsEnumerable().TakeLast(3).ToList();
                            return _mapper.Map<List<MovieDto>>(lastThree);
                        }

                        counterUser++;
                    }

                    var traindata = mlContext.Data.LoadFromEnumerable(data);


                    //STEP 3: Your data is already encoded so all you need to do is specify options for MatrxiFactorizationTrainer with a few extra hyperparameters
                    //        LossFunction, Alpa, Lambda and a few others like K and C as shown below and call the trainer.
                    MatrixFactorizationTrainer.Options options = new MatrixFactorizationTrainer.Options();
                    options.MatrixColumnIndexColumnName = nameof(MovieEntry.MovieId);
                    options.MatrixRowIndexColumnName = nameof(MovieEntry.UserId);
                    options.LabelColumnName = "Label";
                    options.LossFunction = MatrixFactorizationTrainer.LossFunctionType.SquareLossOneClass;
                    options.Alpha = 0.01;
                    options.Lambda = 0.025;
                    // For better results use the following parameters
                    options.NumberOfIterations = 100;
                    options.C = 0.00001;


                    var est = mlContext.Recommendation().Trainers.MatrixFactorization(options);

                    model = est.Fit(traindata);
                }
                else
                {
                    var lastThree = _cinemaContext.Movies.AsEnumerable().TakeLast(3).ToList();
                    return _mapper.Map<List<MovieDto>>(lastThree);
                }
            }
            
            var allItems = await _cinemaContext.Reservations.Where(x => x.Projection!.MovieId != id).ToListAsync();

            var movieFor = await _cinemaContext.Movies.FindAsync(id);
            var movieId = (uint)_cinemaContext.Movies.Local.ToList().IndexOf(movieFor);

            var predictionResult = new List<Tuple<Movie, float>>();

            foreach (var item in allItems)
            {
                var counter = 0;
                var predictionEngine =
                    mlContext.Model.CreatePredictionEngine<MovieEntry, Copurchase_prediction>(model);
                var prediction = predictionEngine.Predict(new MovieEntry()
                {
                    MovieId = (uint)movieId,
                    UserId = (uint)(counter)
                });

                var movie = item!.Projection!.Movie;
                if (movie != null)
                    predictionResult.Add(new Tuple<Movie, float>(movie, prediction.Score));
            }

            var finalResult = predictionResult.OrderByDescending(x => x.Item2)
                .Select(x => x.Item1).Distinct().Take(3).ToList();

            var returnList = await _cinemaContext.Movies.Where(x =>
                    x.Name == finalResult[0].Name || x.Name == finalResult[1].Name || x.Name == finalResult[2].Name)
                .ToListAsync();
            mlContext = null;
            
            return _mapper.Map<List<MovieDto>>(returnList);
        }

       
    }
    
    public class Copurchase_prediction
    {
        public float Score { get; set; }
    }
    
    public class MovieEntry
    {
        [KeyType(count: 10)]
        public uint MovieId { get; set; }
        [KeyType(count: 10)]
        public uint UserId { get; set; }
        
        public float Label { get; set; }
    }
}

