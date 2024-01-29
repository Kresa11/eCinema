using eCinema.Model.Dtos;

namespace eCinema.Model.Requests;

public class ReservationUpsertRequest
{
    public Guid ProjectionId { get; set; }
    
    public Guid UserId { get; set; }
    
    //public ProjectionDto Projection { get; set; }
    public List<SeatDto>? Seats { get; set; }

}