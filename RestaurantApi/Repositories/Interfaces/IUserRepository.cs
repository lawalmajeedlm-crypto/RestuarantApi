using RestaurantApi.Models;

namespace RestaurantApi.Repositories.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        /// <summary>
        /// Find a user by their email address.
        /// </summary>
        /// <param name="email">The email address of the user.</param>
        /// <returns>User entity if found, otherwise null.</returns>
        Task<User?> GetByEmailAsync(string email);

        /// <summary>
        /// Check if a user exists by email.
        /// </summary>
        /// <param name="email">The email address to check.</param>
        /// <returns>True if user exists, false otherwise.</returns>
        Task<bool> ExistsByEmailAsync(string email);
    }
}
