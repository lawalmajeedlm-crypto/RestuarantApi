using RestaurantApi.Models;

namespace RestaurantApi.Repositories.Interfaces
{
    public interface IMenuItemRepository : IGenericRepository<MenuItem>
    {
        /// <summary>
        /// Get all menu items belonging to a specific category.
        /// </summary>
        /// <param name="categoryId">The category ID.</param>
        /// <returns>A collection of menu items.</returns>
        Task<IEnumerable<MenuItem>> GetByCategoryAsync(Guid categoryId);

        /// <summary>
        /// Check if a menu item exists by name.
        /// </summary>
        /// <param name="name">The name of the menu item.</param>
        /// <returns>True if exists, false otherwise.</returns>
        Task<bool> ExistsByNameAsync(string name);
    }
}
