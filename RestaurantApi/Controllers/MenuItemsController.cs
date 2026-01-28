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
    public class MenuItemsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public MenuItemsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("paged")]
        public async Task<IActionResult> GetPaged(int pageNumber = 1, int pageSize = 10)
        {
            var (data, totalRecords) = await _unitOfWork.MenuItems.GetPagedAsync(pageNumber, pageSize);
            var response = new PagedApiResponse<MenuItem>(data, pageNumber, pageSize, totalRecords);
            return Ok(response);
        }

        [HttpGet("category/{categoryId}")]
        public async Task<IActionResult> GetByCategory(Guid categoryId)
        {
            var items = await _unitOfWork.MenuItems.GetByCategoryAsync(categoryId);
            return Ok(ApiResponse<IEnumerable<MenuItem>>.Ok(items));
        }

        [HttpPost]
        public async Task<IActionResult> Create(MenuItem item)
        {
            if (await _unitOfWork.MenuItems.ExistsByNameAsync(item.Name))
                return BadRequest(ApiResponse<string>.Fail("Menu item already exists"));

            await _unitOfWork.MenuItems.AddAsync(item);
            await _unitOfWork.CompleteAsync();

            return Ok(ApiResponse<MenuItem>.Ok(item, "Menu item created successfully"));
        }
    }
}
