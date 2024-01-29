using AutoMapper;
using eCinema.Model.Dtos;
using eCinema.Model.SearchObjects;
using eCinema.Services.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace eCinema.Services.Services
{
    public class HallService : BaseService<HallDto, Hall, BaseSearchObject>, IHallService
    {
        public HallService(CinemaContext cinemaContext, IMapper mapper) : base(cinemaContext, mapper)
        {
        }

        public override IQueryable<Hall> AddInclude(IQueryable<Hall> query, BaseSearchObject search = null)
        {
            query = query.Include(x => x.Seat);
            return query;
        }

        public override async Task<HallDto> GetById(Guid id)
        {
            var entity =  await _cinemaContext.Halls.Include(x => x.Seat).FirstOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<HallDto>(entity);

        }
    }
}
