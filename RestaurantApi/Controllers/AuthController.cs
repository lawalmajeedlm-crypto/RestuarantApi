using Microsoft.AspNetCore.Mvc;
using RestaurantApi.Models;
using RestaurantApi.Repositories.Interfaces;
using RestaurantApi.Common;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

namespace RestaurantApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;

        public AuthController(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }

        /// <summary>
        /// Register a new user.
        /// </summary>
        [HttpPost("register")]
        public async Task<IActionResult> Register(User user)
        {
            if (await _unitOfWork.Users.ExistsByEmailAsync(user.Email))
                return BadRequest(ApiResponse<string>.Fail("Email already registered"));

            await _unitOfWork.Users.AddAsync(user);
            await _unitOfWork.CompleteAsync();

            return Ok(ApiResponse<User>.Ok(user, "User registered successfully"));
        }

        /// <summary>
        /// Login with email and password.
        /// </summary>
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var user = await _unitOfWork.Users.GetByEmailAsync(request.Email);
            if (user == null || user.PasswordHash != request.Password) // ⚠️ Simplified check
                return Unauthorized(ApiResponse<string>.Fail("Invalid email or password"));
            // Generate JWt
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var Key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(jwtSettings["SecretKey"]));
            var creds = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256);

            var Claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim("userId", user.Id.ToString())
            };
            var token = new JwtSecurityToken(
                issuer: jwtSettings["Issuer"],
                audience: jwtSettings["Audience"],
                claims: Claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: creds
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            var response = new
            {
                User = user,
                Token = tokenString,
            };
            return Ok(ApiResponse<object>.Ok(response, "Login successful"));
        }

        /// <summary>
        /// DTO for login requests.
        /// </summary>
        public class LoginRequest
        {
            public string Email { get; set; } = string.Empty;
            public string Password { get; set; } = string.Empty;
        }
    }
}
