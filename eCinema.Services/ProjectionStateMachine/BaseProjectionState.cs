using AutoMapper;
using eCinema.Model.Dtos;
using eCinema.Model.Requests;
using eCinema.Model.Constants;
using eCinema.Services.Database;
using Microsoft.Extensions.DependencyInjection;

namespace eCinema.Services.ProjectionStateMachine;

public class BaseProjectionState
{
    protected readonly IMapper _mapper;
    private readonly IServiceProvider _serviceProvider;
    protected readonly CinemaContext _cinemaContext;

    public BaseProjectionState(IMapper mapper, IServiceProvider serviceProvider, CinemaContext cinemaContext)
    {
        _mapper = mapper;
        _serviceProvider = serviceProvider;
        _cinemaContext = cinemaContext;
    }

    public Projection CurrentEntity { get; set; }
    public string CurrentState { get; set; }
    
    public virtual Task<ProjectionDto> Insert(ProjectionUpsertRequest request)
    {
        throw new Exception("Not allowed");
    }

    public virtual Task Update(ProjectionUpsertRequest request)
    {
        throw new Exception("Not allowed");
    }

    public virtual Task Activate()
    {
        throw new Exception("Not allowed");
    }

    public virtual Task Hide()
    {
        throw new Exception("Not allowed");
    }

    public virtual Task Delete()
    {
        throw new Exception("Not allowed");
    }
    
    public BaseProjectionState CreateState(string stateName)
    {
        if (_serviceProvider is null)
            throw new Exception("Invalid service provider!");
        switch (stateName)
        {
            case StateMachineConstants.InitialState:
                return _serviceProvider.GetService<InitialProjectionState>()!;
            case StateMachineConstants.DraftState:
                return _serviceProvider.GetService<DraftProjectionState>()!;
            case StateMachineConstants.ActiveState:
                return _serviceProvider.GetService<ActiveProjectionState>()!;
            case StateMachineConstants.HiddenState:
                return _serviceProvider.GetService<HiddenProjectionState>()!;
            default:
                throw new Exception("Not supported");
        }
    }
    
    public virtual List<string> AllowedActions()
    {
        return new List<string>();
    }
}