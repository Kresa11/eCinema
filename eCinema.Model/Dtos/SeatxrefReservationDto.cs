namespace eCinema.Model.Dtos;

public class SeatxrefReservationDto
{
    public Guid Id { get; set; }
    
    public Guid SeatId { get; set; }

    public SeatDto Seat { get; set; }
    
    public Guid ReservationId { get; set; }
    
    public bool IsTaken { get; set; }
}