using AutoMapper;
using eCinema.Model.SearchObjects;
using eCinema.Services.Database;
using Microsoft.EntityFrameworkCore;

namespace eCinema.Services.Services
{
    public class BaseService<T, TDb, TSearch> : IService<T, TSearch> where T : class where TDb : class where TSearch : BaseSearchObject
    {
        public readonly CinemaContext _cinemaContext;
        public readonly IMapper _mapper;

        public BaseService(CinemaContext cinemaContext, IMapper mapper)
        {
            _cinemaContext = cinemaContext;
            _mapper = mapper;
        }

        public virtual async Task<IEnumerable<T>> GetAll(TSearch? search = null)
        {
            var entity = _cinemaContext.Set<TDb>().AsQueryable();
            if (search is not null)
            {
                entity = AddFilter(entity, search);
                if (search.Page.HasValue && search.PageSize.HasValue)
                    entity = entity.Skip(search.Page.Value * search.PageSize.Value).Take(search.PageSize.Value);
                entity = AddInclude(entity, search);
            }
            
            var list =  await entity.ToListAsync();

           return _mapper.Map<IList<T>>(list);

        }

        public virtual async Task<T> GetById(Guid id)
        {
            var set = _cinemaContext.Set<TDb>();

            var entity = await set.FindAsync(id);

            return _mapper.Map<T>(entity);
            
        }

        public virtual IQueryable<TDb> AddFilter (IQueryable<TDb> query, TSearch search = null)
        {
            return query;
        }

        public virtual IQueryable<TDb> AddInclude(IQueryable<TDb> query, TSearch search = null)
        {
            return query;
        }

    }
}
