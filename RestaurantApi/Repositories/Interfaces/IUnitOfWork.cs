using RestaurantApi.Models;

namespace RestaurantApi.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        IMenuItemRepository MenuItems { get; }
        IOrderRepository Orders { get; }
        IReservationRepository Reservations { get; }

        Task<int> CompleteAsync();
    }
}
