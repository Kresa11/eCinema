namespace eCinema.Model.SearchObjects
{
    public class ProjectionSearchObject : BaseSearchObject
    {
        public DateTime? StartDate { get; set; }

        public Guid? HallId { get; set; }

        public string? Name { get; set; }

        public string? StateMachine { get; set; }

        public bool? IncludeMovies { get; set; }

        public bool? IncludeHalls { get; set; }

        public bool? IncludePrices { get; set; }
    }
}
