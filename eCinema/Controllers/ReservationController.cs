using eCinema.Model.Dtos;
using eCinema.Model.Requests;
using eCinema.Model.SearchObjects;
using eCinema.Services.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eCinema.Controllers
{
    public class ReservationController : BaseCRUDController<ReservationDto, ReservationSearchObject, ReservationUpsertRequest, ReservationUpsertRequest>
    {
        private readonly IReservationService _reservationService;
        public ReservationController(IReservationService reservationService)
            : base(reservationService)
        {
            _reservationService = reservationService;
        }
    }
}
