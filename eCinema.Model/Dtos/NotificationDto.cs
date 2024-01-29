namespace eCinema.Model.Dtos
{
    public class NotificationDto
    {
        public Guid Id { get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }

        public DateTime? Date { get; set; }

        public Guid AuthorId { get; set; }
        public UserDto Author { get; set; }

        public string? AuthorName
        {
            get
            {
                return Author?.FirstName + " " + Author?.LastName;
            }
        }

        public string? NotificationType { get; set; }

        public string? Picture { get; set; }
        
        public bool? IsActive { get; set; }

    }
}
