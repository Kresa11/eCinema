using eCinema.Model.Dtos;
using eCinema.Model.SearchObjects;
using eCinema.Services.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eCinema.Controllers
{
    public class HallController : BaseController<HallDto, BaseSearchObject>
    {
        public HallController(IHallService service) : base(service)
        {
        }
    }
}
