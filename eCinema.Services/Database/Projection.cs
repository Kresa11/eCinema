namespace eCinema.Services.Database
{
    public class Projection
    {
        public Guid Id { get; set; }

        public DateTime? StartTime { get; set; }
        
        public DateTime? EndTime { get; set; }

        public Guid? HallId { get; set; }
        public Hall? Hall { get; set; }

        public Guid? MovieId { get; set; }

        public Movie? Movie { get; set; }
        
        public Guid PriceId { get; set; }
    
        public Price Price { get; set; }

        public string? StateMachine { get; set; }

        public bool? IsActive { get; set; }
        
        public ICollection<Reservation>? Reservations { get; set; }

    }
}
