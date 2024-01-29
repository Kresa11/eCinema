namespace eCinema.Model.Dtos
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string? FirstName { get; set; }

        public string? LastName { get; set; }
        public string? FullName => $"{FirstName} {LastName}";

        public string? Email { get; set; }
        
        public string? Username { get; set; }
        
        public string? PhoneNumber { get; set; }

        public RoleDto? Role { get; set; }

        public string? UserRole => Role?.Name;
        public string? CustomerId { get; set; }

        public bool? IsActive { get; set; }
        

    }
}
