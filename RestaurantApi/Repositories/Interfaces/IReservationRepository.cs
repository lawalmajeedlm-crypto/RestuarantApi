using RestaurantApi.Models;

namespace RestaurantApi.Repositories.Interfaces
{
    public interface IReservationRepository : IGenericRepository<Reservation>
    {
        /// <summary>
        /// Get all upcoming reservations for a specific customer.
        /// </summary>
        /// <param name="customerId">The customer ID.</param>
        /// <returns>A collection of reservations.</returns>
        Task<IEnumerable<Reservation>> GetUpcomingReservationsAsync(Guid customerId);

        /// <summary>
        /// Get reservations for a specific date.
        /// </summary>
        /// <param name="date">The reservation date.</param>
        /// <returns>A collection of reservations.</returns>
        Task<IEnumerable<Reservation>> GetByDateAsync(DateTime date);

        /// <summary>
        /// Check if a reservation exists for a customer at a given date/time.
        /// </summary>
        /// <param name="customerId">The customer ID.</param>
        /// <param name="dateTime">The reservation date/time.</param>
        /// <returns>True if exists, false otherwise.</returns>
        Task<bool> ExistsAsync(Guid customerId, DateTime dateTime);
    }
}
