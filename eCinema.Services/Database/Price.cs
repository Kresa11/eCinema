namespace eCinema.Services.Database
{
    public class Price
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public decimal? Value { get; set; }

        public bool? IsActive { get; set; }

        public ICollection<Projection>? Projections { get; set; }


    }
}
