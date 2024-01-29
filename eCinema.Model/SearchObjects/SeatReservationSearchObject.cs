namespace eCinema.Model.SearchObjects;

public class SeatReservationSearchObject : BaseSearchObject
{
    public Guid? ProjectionId { get; set; }
    public Guid? ReservationId { get; set; }
    public bool IncludeSeats { get; set; }
}