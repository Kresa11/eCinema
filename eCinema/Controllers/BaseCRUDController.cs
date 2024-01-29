using eCinema.Model.SearchObjects;
using eCinema.Services.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eCinema.Controllers
{
    [Authorize]
    public class BaseCRUDController<T, TSearch, TInsert, TUpdate> : BaseController<T, TSearch>
        where T : class where TSearch : BaseSearchObject where TInsert : class where TUpdate : class
    {
        private readonly ICRUDService<T, TSearch, TInsert, TUpdate> _baseCRUDService;
        public BaseCRUDController(ICRUDService<T, TSearch, TInsert, TUpdate> service) : base(service)
        {
            _baseCRUDService = service;
        }

        [HttpPost]
        public virtual async Task<T> Insert([FromBody]TInsert insert)
        {
            return await _baseCRUDService.Insert(insert);
        }

        [HttpPut("{id}")]
        public virtual async Task<T> Update(Guid id, TUpdate update)
        {
            return await _baseCRUDService.Update(id, update);
        }
        
        [HttpPut("{id}/Delete")]
        public virtual async Task<T> Delete(Guid id)
        {
            return await _baseCRUDService.Delete(id);
        }

        [HttpPut("{id}/HardDelete")]
        public virtual async Task<T> HardDelete(Guid id)
        {
            return await _baseCRUDService.HardDelete(id);
        }

    }
}
