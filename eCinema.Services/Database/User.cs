namespace eCinema.Services.Database
{
    public class User
    {
        public Guid Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Email { get; set; }
        
        public string? Username { get; set; }

        public string? PhoneNumber { get; set; }

        public string? LozinkaHash { get; set; }

        public string? LozinkaSalt { get; set; }

        public string? CustomerId { get; set; }

        public Guid RoleId { get; set; }

        public Role Role { get; set; }

        public ICollection<Notification> Notifications { get; set; }

        public ICollection<Reservation> Reservations { get; set; }
        
        public bool? IsActive { get; set; }

    }
}
