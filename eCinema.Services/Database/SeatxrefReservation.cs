namespace eCinema.Services.Database;

public class SeatxrefReservation
{
    public Guid Id { get; set; }
    
    public Guid SeatId { get; set; }
    
    public Seat Seat { get; set; }
    
    public Guid ReservationId { get; set; }
    
    public Reservation Reservation { get; set; }
    
    public bool IsTaken { get; set; }
}