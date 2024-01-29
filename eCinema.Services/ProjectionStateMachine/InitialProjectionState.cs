using AutoMapper;
using eCinema.Model.Dtos;
using eCinema.Model.Helpers;
using eCinema.Model.Requests;
using eCinema.Model.Constants;
using eCinema.Services.Database;

namespace eCinema.Services.ProjectionStateMachine;

public class InitialProjectionState : BaseProjectionState
{
    public InitialProjectionState(IMapper mapper, IServiceProvider serviceProvider, CinemaContext cinemaContext) : base(mapper, serviceProvider, cinemaContext)
    {
    }

    public override async Task<ProjectionDto> Insert(ProjectionUpsertRequest request)
    {
        var set = _cinemaContext.Set<Projection>();
        
        CurrentEntity =  _mapper.Map<Projection>(request);
        CurrentEntity.StateMachine = StateMachineConstants.DraftState;

        await set.AddAsync(CurrentEntity);
        IsActiveHelper<Projection>.SetIsActive(CurrentEntity,true);

        await _cinemaContext.SaveChangesAsync();

        return _mapper.Map<ProjectionDto>(CurrentEntity);
    }
}