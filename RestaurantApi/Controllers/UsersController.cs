using Microsoft.AspNetCore.Mvc;
using RestaurantApi.Models;
using RestaurantApi.Repositories.Interfaces;
using RestaurantApi.Common;
using Microsoft.AspNetCore.Authorization;

namespace RestaurantApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public UsersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(Guid id)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(id);
            if (user == null)
                return NotFound(ApiResponse<string>.Fail("User not found"));

            return Ok(ApiResponse<User>.Ok(user));
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(User user)
        {
            if (await _unitOfWork.Users.ExistsByEmailAsync(user.Email))
                return BadRequest(ApiResponse<string>.Fail("Email already registered"));

            await _unitOfWork.Users.AddAsync(user);
            await _unitOfWork.CompleteAsync();

            return Ok(ApiResponse<User>.Ok(user, "User created successfully"));
        }
    }
}
