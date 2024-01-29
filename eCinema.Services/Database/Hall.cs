namespace eCinema.Services.Database
{
    public class Hall
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }
        
        public ICollection<Seat>? Seat { get; set; }

    }
}
