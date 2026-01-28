using RestaurantApi.Models;

namespace RestaurantApi.Repositories.Interfaces
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        /// <summary>
        /// Get all orders placed by a specific customer.
        /// </summary>
        /// <param name="customerId">The customer ID.</param>
        /// <returns>A collection of orders.</returns>
        Task<IEnumerable<Order>> GetByCustomerAsync(Guid customerId);

        /// <summary>
        /// Get all orders with a specific status.
        /// </summary>
        /// <param name="status">The order status.</param>
        /// <returns>A collection of orders.</returns>
        Task<IEnumerable<Order>> GetByStatusAsync(OrderStatus status);

        /// <summary>
        /// Check if an order exists by its reference number.
        /// </summary>
        /// <param name="reference">The order reference string.</param>
        /// <returns>True if exists, false otherwise.</returns>
        Task<bool> ExistsByReferenceAsync(string reference);
    }
}
