namespace eCinema.Model.SearchObjects
{
    public class NotificationSearchObject : BaseSearchObject
    {
        public string? Title { get; set; }

        public string? NotificationType { get; set; }
        public Guid AuthorId { get; set; }

        public string? Author { get; set; }

        public bool? IncludeUsers { get; set; }

    }
}
