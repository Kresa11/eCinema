namespace eCinema.Model.Dtos
{
    public class ProjectionDto
    {
        public Guid Id { get; set; }

        public DateTime? StartTime { get; set; }
        
        public DateTime? EndTime { get; set; }

        public Guid HallId { get; set; }
        public HallDto Hall { get; set; }
        public string? HallName => Hall?.Name;


        public Guid MovieId { get; set; }
        public MovieDto Movie { get; set; }
        public string? MovieName => Movie?.Name;


        public Guid? PriceId { get; set; }
        public PriceDto Price { get; set; }
        public string? PriceName => Price?.Name;

        public string? StateMachine { get; set; }

        public bool? IsActive { get; set; }

    }
}
