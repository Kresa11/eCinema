using eCinema.Model.Dtos;
using eCinema.Model.Requests;
using eCinema.Model.SearchObjects;

namespace eCinema.Services.Services
{
    public interface IPriceService : ICRUDService<PriceDto, PriceSearchObject,
       PriceUpsertRequest, PriceUpsertRequest>
    {
    }
}
