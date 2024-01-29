namespace eCinema.Services.Database
{
    public class Movie
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public int? Duration { get; set; }

        public int? ReleaseYear { get; set; }

        public string? Country { get; set; }

        public string? Actors { get; set; }
        public string? Director { get; set; }
        
        public string? Picture { get; set; }
        public string? Genres { get; set; }

        public ICollection<Projection>? Projections { get; set; }
        
        public bool? IsActive { get; set; }

    }
}
