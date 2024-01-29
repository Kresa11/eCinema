namespace eCinema.Model.SearchObjects
{
    public class UserSearchObject : BaseSearchObject
    {
        public string? Name { get; set; }

        public string? Username { get; set; }

        public string? Role { get; set; }

        public bool? IsActive { get; set; }

        public bool? IncludeRoles { get; set; }

    }
}
