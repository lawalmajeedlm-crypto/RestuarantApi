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
    public class ReservationsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ReservationsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("customer/{customerId}")]
        public async Task<IActionResult> GetUpcoming(Guid customerId)
        {
            var reservations = await _unitOfWork.Reservations.GetUpcomingReservationsAsync(customerId);
            return Ok(ApiResponse<IEnumerable<Reservation>>.Ok(reservations));
        }

        [HttpGet("date/{date}")]
        public async Task<IActionResult> GetByDate(DateTime date)
        {
            var reservations = await _unitOfWork.Reservations.GetByDateAsync(date);
            return Ok(ApiResponse<IEnumerable<Reservation>>.Ok(reservations));
        }

        [HttpPost]
        public async Task<IActionResult> Create(Reservation reservation)
        {
            if (await _unitOfWork.Reservations.ExistsAsync(reservation.CustomerId, reservation.DateTime))
                return BadRequest(ApiResponse<string>.Fail("Reservation already exists for this time"));

            await _unitOfWork.Reservations.AddAsync(reservation);
            await _unitOfWork.CompleteAsync();

            return Ok(ApiResponse<Reservation>.Ok(reservation, "Reservation created successfully"));
        }
    }
}
