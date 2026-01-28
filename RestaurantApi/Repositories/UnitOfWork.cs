using RestaurantApi.Data;
using RestaurantApi.Models;
using RestaurantApi.Repositories.Interfaces;

namespace RestaurantApi.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RestaurantDbContext _context;

        public IUserRepository Users { get; }
        public IMenuItemRepository MenuItems { get; }
        public IOrderRepository Orders { get; }
        public IReservationRepository Reservations { get; }

        public UnitOfWork(RestaurantDbContext context)
        {
            _context = context;
            Users = new UserRepository(_context);
            MenuItems = new MenuItemRepository(_context);
            Orders = new OrderRepository(_context);
            Reservations = new ReservationRepository(_context);
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
