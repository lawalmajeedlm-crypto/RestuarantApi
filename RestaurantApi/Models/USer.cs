namespace RestaurantApi.Models
{
    public enum Role
    {
        Admin,
        User,
        Manager
    }

    public class User : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public Role Role { get; set; }

        public bool HasRole(Role role) => Role == role;
    }
}
