using Microsoft.EntityFrameworkCore;
using RestaurantApi.Data;
using RestaurantApi.Models;
using RestaurantApi.Repositories.Interfaces;

namespace RestaurantApi.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(RestaurantDbContext context) : base(context) { }

        public async Task<IEnumerable<Order>> GetByCustomerAsync(Guid customerId)
        {
            return await _dbSet
                .Where(o => o.CustomerId == customerId && !o.IsDeleted)
                .Include(o => o.Items) // eager load order items
                .ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetByStatusAsync(OrderStatus status)
        {
            return await _dbSet
                .Where(o => o.Status == status && !o.IsDeleted)
                .Include(o => o.Items)
                .ToListAsync();
        }

        public async Task<bool> ExistsByReferenceAsync(string reference)
        {
            return await _dbSet.AnyAsync(o => o.ReferenceNumber == reference && !o.IsDeleted);
        }
    }
}
