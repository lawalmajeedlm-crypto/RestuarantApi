using Microsoft.EntityFrameworkCore;
using RestaurantApi.Data;
using RestaurantApi.Models;
using RestaurantApi.Repositories.Interfaces;

namespace RestaurantApi.Repositories
{
    public class ReservationRepository : GenericRepository<Reservation>, IReservationRepository
    {
        public ReservationRepository(RestaurantDbContext context) : base(context) { }

        public async Task<IEnumerable<Reservation>> GetUpcomingReservationsAsync(Guid customerId)
        {
            return await _dbSet
                .Where(r => r.CustomerId == customerId && r.DateTime > DateTime.UtcNow && !r.IsDeleted)
                .ToListAsync();
        }

        public async Task<IEnumerable<Reservation>> GetByDateAsync(DateTime date)
        {
            return await _dbSet
                .Where(r => r.DateTime.Date == date.Date && !r.IsDeleted)
                .ToListAsync();
        }

        public async Task<bool> ExistsAsync(Guid customerId, DateTime dateTime)
        {
            return await _dbSet.AnyAsync(r => r.CustomerId == customerId && r.DateTime == dateTime && !r.IsDeleted);
        }
    }
}
