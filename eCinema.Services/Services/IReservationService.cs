using eCinema.Model.Dtos;
using eCinema.Model.Requests;
using eCinema.Model.SearchObjects;
using Microsoft.AspNetCore.Http;

namespace eCinema.Services.Services
{
    public interface IReservationService : ICRUDService<ReservationDto, ReservationSearchObject,
        ReservationUpsertRequest, ReservationUpsertRequest>
    {
    }
}
