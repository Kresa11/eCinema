namespace eCinema.Model.SearchObjects
{
    public class MovieSearchObject : BaseSearchObject
    {
        public string? Name { get; set; }

        public string? Director { get; set; }

        public string? Genres { get; set; }
        public bool? HasProjection { get; set; }
        public bool? IsActive { get; set; }
    }
}
