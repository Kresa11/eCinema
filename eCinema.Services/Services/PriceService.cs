using AutoMapper;
using eCinema.Model.Dtos;
using eCinema.Model.Requests;
using eCinema.Model.SearchObjects;
using eCinema.Services.Database;
using Microsoft.EntityFrameworkCore;

namespace eCinema.Services.Services
{
    public class PriceService : BaseCRUDService<PriceDto, Price, PriceSearchObject, PriceUpsertRequest, PriceUpsertRequest>,
        IPriceService
    {
        public PriceService(CinemaContext cinemaContext, IMapper mapper) : base(cinemaContext, mapper)
        {
        }

        public override IQueryable<Price> AddFilter(IQueryable<Price> query, PriceSearchObject search)
        {
            var filteredQuery = query;

            if (!string.IsNullOrWhiteSpace(search.Name))
                filteredQuery = filteredQuery.Where(x => x.Name!.ToLower().Contains(search.Name.ToLower()));

            if (search?.IsActive is not null)
            {
                filteredQuery = filteredQuery.Where(x => x.IsActive == search.IsActive);
            }

            return filteredQuery;

        }

        public async override Task<PriceDto> Delete(Guid id)
        {
            var price = await _cinemaContext.Prices.FindAsync(id);

            if (await _cinemaContext.Projections.AnyAsync(x => x.PriceId == id) == false)
            {
                return await base.Delete(id);
            }
            else
            {
                throw new Exception("This price has active projections!");
            }

        }

    }
}
