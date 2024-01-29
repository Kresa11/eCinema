namespace eCinema.Model.Requests
{
    public class NotificationInsertRequest
    {
        public string? Title { get; set; }

        public string? Description { get; set; }

        public string? NotificationType { get; set; }

        public string? Picture { get; set; }

        public Guid AuthorId { get; set; }
    }
}
