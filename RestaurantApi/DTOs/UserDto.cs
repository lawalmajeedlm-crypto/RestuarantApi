namespace RestaurantApi.DTOs
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } 
        public string Email { get; set; } 
        public string Role { get; set; }
    }

    public class CreateUserDto
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty; // plain password for registration
        public string Role { get; set; } = "Customer";
    }

    public class RegisterUserDto
    { 
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; }
    }

    public class LoginDto
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
