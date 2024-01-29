using eCinema.Model.Dtos;
using eCinema.Model.SearchObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCinema.Services.Services
{
    public interface IHallService : IService<HallDto, BaseSearchObject>
    {
    }
}
