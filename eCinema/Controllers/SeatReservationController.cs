using eCinema.Model.Dtos;
using eCinema.Model.SearchObjects;
using eCinema.Services.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eCinema.Controllers
{
    public class SeatReservationController : BaseController<SeatxrefReservationDto, SeatReservationSearchObject>
    {
        public SeatReservationController(ISeatReservationService service) : base(service)
        {
        }
    }
}
