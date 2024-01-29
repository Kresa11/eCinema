namespace eCinema.Model.SearchObjects;

public class ReservationSearchObject : BaseSearchObject
{
    public DateTime? DateTime { get; set; }

    public string? Name { get; set; }
    
    public Guid? UserId { get; set; }
    public Guid? ProjectionId { get; set; }
    public string? User { get; set; }
    
    public bool? IncludeUsers { get; set; }
    public bool? IncludeMovies { get; set; }

    public bool? IncludePrices { get; set; }

    public bool? IncludePayments { get; set; }

    public bool? IncludeProjection { get; set; }
    public bool? IncludeSeatsReservations { get; set; }

}