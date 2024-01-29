using eCinema.Model.Dtos;
using eCinema.Model.Requests;
using eCinema.Model.SearchObjects;
using eCinema.Services.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eCinema.Controllers
{
    public class ProjectionController : BaseCRUDController<ProjectionDto, ProjectionSearchObject, ProjectionUpsertRequest, ProjectionUpsertRequest>
    {
        private readonly IProjectionService _projectionService;
        public ProjectionController(IProjectionService projectionService)
            : base(projectionService)
        {
            _projectionService = projectionService;
        }
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}/AllowedActions")]
        public async Task<List<string>> AllowedActions(Guid id)
        {
            return await _projectionService.AllowedActions(id);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}/Activate")]
        public async Task<ProjectionDto> Activate(Guid id)
        {
            return await _projectionService.Activate(id);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}/Hide")]
        public async Task<ProjectionDto> Hide(Guid id)
        {
            return await _projectionService.Hide(id);
        }

    }
}
