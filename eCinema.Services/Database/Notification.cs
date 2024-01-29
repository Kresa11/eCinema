namespace eCinema.Services.Database
{
    public class Notification
    {
        public Guid Id { get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }
        
        public DateTime? Date { get; set; }
        
        public Guid AuthorId { get; set; }

        public User? Author { get; set; }
        
        public string? NotificationType { get; set; }

        public string? Picture { get; set; }
        
        public bool? IsActive { get; set; }

    }
}
