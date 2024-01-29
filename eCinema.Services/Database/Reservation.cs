namespace eCinema.Services.Database
{
    public class Reservation
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public User? User { get; set; }
        
        public Guid ProjectionId { get; set; }
        
        public Projection? Projection { get; set; }
        
        public bool? IsActive { get; set; }
        public DateTime? DateTime { get; set; }
        
        public Payment? Payment { get; set; }
        
        public ICollection<SeatxrefReservation>? SeatsReservations { get; set; }
    }
}
