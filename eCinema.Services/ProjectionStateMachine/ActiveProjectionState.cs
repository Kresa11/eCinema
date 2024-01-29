using AutoMapper;
using eCinema.Model.Constants;
using eCinema.Services.Database;

namespace eCinema.Services.ProjectionStateMachine;

public class ActiveProjectionState : BaseProjectionState
{
    public ActiveProjectionState(IMapper mapper, IServiceProvider serviceProvider, CinemaContext cinemaContext) : base(mapper, serviceProvider, cinemaContext)
    {
    }

    public override async Task Hide()
    {   
        CurrentEntity.StateMachine = StateMachineConstants.HiddenState;
        await _cinemaContext.SaveChangesAsync();
    }

    public override List<string> AllowedActions()
    {
        return new List<string>{"Hide"};
    }
}