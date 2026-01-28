using Microsoft.EntityFrameworkCore;
using RestaurantApi.Data;
using RestaurantApi.Models;
using RestaurantApi.Repositories.Interfaces;

namespace RestaurantApi.Repositories
{
    public class MenuItemRepository : GenericRepository<MenuItem>, IMenuItemRepository
    {
        public MenuItemRepository(RestaurantDbContext context) : base(context) { }

        public async Task<IEnumerable<MenuItem>> GetByCategoryAsync(Guid categoryId)
        {
            return await _dbSet
                .Where(m => m.CategoryId == categoryId && !m.IsDeleted)
                .ToListAsync();
        }

        public async Task<bool> ExistsByNameAsync(string name)
        {
            return await _dbSet.AnyAsync(m => m.Name == name && !m.IsDeleted);
        }
    }
}
