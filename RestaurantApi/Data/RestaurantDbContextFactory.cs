using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace RestaurantApi.Data
{
    public class RestaurantDbContextFactory : IDesignTimeDbContextFactory<RestaurantDbContext>
    {
        public RestaurantDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<RestaurantDbContext>();

            // ✅ Use the same connection string as in appsettings.json
            optionsBuilder.UseSqlServer("Server=localhost;Database=RestaurantDb;Trusted_Connection=True;TrustServerCertificate=True;");

            return new RestaurantDbContext(optionsBuilder.Options);
        }
    }
}
