using Microsoft.AspNetCore.Mvc;
using RestaurantApi.Models;
using RestaurantApi.Repositories.Interfaces;
using RestaurantApi.Common;

namespace RestaurantApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrdersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("customer/{customerId}")]
        public async Task<IActionResult> GetByCustomer(Guid customerId)
        {
            var orders = await _unitOfWork.Orders.GetByCustomerAsync(customerId);
            return Ok(ApiResponse<IEnumerable<Order>>.Ok(orders));
        }

        [HttpGet("status/{status}")]
        public async Task<IActionResult> GetByStatus(OrderStatus status)
        {
            var orders = await _unitOfWork.Orders.GetByStatusAsync(status);
            return Ok(ApiResponse<IEnumerable<Order>>.Ok(orders));
        }

        [HttpPost]
        public async Task<IActionResult> Create(Order order)
        {
            await _unitOfWork.Orders.AddAsync(order);
            await _unitOfWork.CompleteAsync();

            return Ok(ApiResponse<Order>.Ok(order, "Order created successfully"));
        }
    }
}
