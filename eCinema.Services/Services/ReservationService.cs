using AutoMapper;
using eCinema.Model.Dtos;
using eCinema.Model.Requests;
using eCinema.Model.SearchObjects;
using eCinema.Services.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eCinema.Services.Services
{
    public class ReservationService : BaseCRUDService<ReservationDto, Reservation, ReservationSearchObject, ReservationUpsertRequest, ReservationUpsertRequest>,
        IReservationService
    {
        public ReservationService(CinemaContext cinemaContext, IMapper mapper) : base(cinemaContext, mapper)
        {
        }
        
        public override async Task<ReservationDto> Insert(ReservationUpsertRequest insert)
        {
            var seatsId = insert.Seats?.Select(x => x.Id).ToList();
          
                if (await CheckSeat(seatsId, insert.ProjectionId))
                {
                    throw new Exception("Seat unavailable!");
                }
       
                //var user = await _cinemaContext.Users.FirstOrDefaultAsync();

                var reservation = new Reservation
                {
                    UserId = insert.UserId,
                    DateTime = DateTime.Now,
                    IsActive = true,
                    ProjectionId = insert.ProjectionId
                };
                await _cinemaContext.AddAsync(reservation);
                await _cinemaContext.SaveChangesAsync();

                var seatList = new List<SeatxrefReservation>();

                foreach (var seatId in seatsId)
                {
                    seatList.Add(new SeatxrefReservation
                    {
                        ReservationId = reservation.Id,
                        SeatId = seatId,
                        IsTaken = true
                    });
                }

                await _cinemaContext.AddRangeAsync(seatList);
                await _cinemaContext.SaveChangesAsync();

                return _mapper.Map<ReservationDto>(reservation);
            }

        private async Task<bool> CheckSeat(List<Guid> insertSeatsId, Guid projectionId)
        {
            //if(insertSeatsId == null || projectionId == null)
            foreach (var seatId in insertSeatsId )
            {
                var flag = await _cinemaContext.SeatReservations.Include(x=> x.Reservation)
                    .AnyAsync(x => x.SeatId == seatId && x.Reservation.ProjectionId == projectionId);
                if (flag)
                {
                    return flag;
                }
            }
            return false;
        }

        public override IQueryable<Reservation> AddInclude(IQueryable<Reservation> query, ReservationSearchObject search = null)
        {
            if(search?.IncludeSeatsReservations is true)
                query = query.Include(x => x.SeatsReservations);
            if (search?.IncludeProjection is true)
                query = query.Include(x => x.Projection);
            if (search?.IncludeMovies is true)
                query = query.Include(x => x.Projection!.Movie);
            if (search?.IncludePrices is true)
                query = query.Include(x => x.Projection!.Price);
            if (search?.IncludeUsers is true)
                query = query.Include(x => x.User); 
            if (search?.IncludePayments is true)
                query = query.Include(x => x.Payment);
    
            return query;
        }
        
        public override IQueryable<Reservation> AddFilter(IQueryable<Reservation> query, ReservationSearchObject search)
        {
            var filteredQuery = query;

            if (!string.IsNullOrWhiteSpace(search.Name))
                filteredQuery = filteredQuery.Include(x => x.Projection.Movie)
                    .Where(x => x.Projection.Movie.Name.ToLower().Contains(search.Name.ToLower()));

            if (!string.IsNullOrWhiteSpace(search.User))
                filteredQuery = filteredQuery.Include(x => x.User).Where(x => x.User.FirstName.ToLower().Contains(search.User.ToLower())
                || x.User.LastName.ToLower().Contains(search.User.ToLower()));

            if (search.UserId != Guid.Empty && search.UserId is not null)
                filteredQuery = filteredQuery.Where(x => x.UserId! == search.UserId);

            if (search.ProjectionId != Guid.Empty && search.ProjectionId is not null)
                filteredQuery = filteredQuery.Where(x => x.ProjectionId! == search.ProjectionId);

            if (search.DateTime is not null)
                filteredQuery = filteredQuery.Where(x => x.DateTime.Value.Date == search.DateTime.Value.Date);

            return filteredQuery.OrderByDescending(x=> x.DateTime);

        }
    }
}
