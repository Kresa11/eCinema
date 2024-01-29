namespace eCinema.Model.Dtos;

public class ReservationDto
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public UserDto User { get; set; }

    public Guid ProjectionId { get; set; }
    
    public ProjectionDto Projection { get; set; }
    
    public bool? IsActive { get; set; }

    public ICollection<SeatxrefReservationDto>? SeatsReservations { get; set; }
    
    public DateTime? DateTime { get; set; }

    public PaymentDto Payment { get; set; }


}