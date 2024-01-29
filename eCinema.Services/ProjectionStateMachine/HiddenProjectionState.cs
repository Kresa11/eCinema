using AutoMapper;
using eCinema.Model.Helpers;
using eCinema.Model.Requests;
using eCinema.Model.Constants;
using eCinema.Services.Database;

namespace eCinema.Services.ProjectionStateMachine;

public class HiddenProjectionState : BaseProjectionState
{
    public HiddenProjectionState(IMapper mapper, IServiceProvider serviceProvider, CinemaContext cinemaContext) : base(mapper, serviceProvider, cinemaContext)
    {
    }
    
    public override async Task Update(ProjectionUpsertRequest request)
    {
        _mapper.Map(request, CurrentEntity);
        CurrentEntity.StateMachine = StateMachineConstants.HiddenState;

        await _cinemaContext.SaveChangesAsync();

    }
    
    public override async Task Activate()
    {
        CurrentEntity.StateMachine = StateMachineConstants.ActiveState;

        await _cinemaContext.SaveChangesAsync();

    }
    
    public override async Task Delete()
    {
        CurrentEntity.StateMachine = StateMachineConstants.DeletedState;
        
        IsActiveHelper<Projection>.SetIsActive(CurrentEntity,false);

        await _cinemaContext.SaveChangesAsync();
    }
    
    public override List<string> AllowedActions()
    {
        return new List<string>{"Update", "Activate", "Delete"};
    }
}