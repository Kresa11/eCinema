using eCinema.Model.SearchObjects;
using eCinema.Services.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eCinema.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BaseController<T, TSearch> : ControllerBase where T : class where TSearch : BaseSearchObject
    {
        private readonly IService<T, TSearch> _service;

        public BaseController(IService<T, TSearch> service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<T>> Get([FromQuery] TSearch? search)
        {
            return await _service.GetAll(search);
        }

        [HttpGet("{id}")]
        public async Task<T> GetById(Guid id)
        {
            return await _service.GetById(id);
        }
    }
}
