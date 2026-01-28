using Microsoft.EntityFrameworkCore;
using RestaurantApi.Models;
using System.Linq.Expressions;

namespace RestaurantApi.Data
{
    public class RestaurantDbContext : DbContext
    {
        public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options)
            : base(options)
        {
        }

        // DbSets for each entity
        public DbSet<User> Users { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Concurrency token for RowVersion
            modelBuilder.Entity<BaseEntity>()
                .Property(e => e.RowVersion)
                .IsRowVersion();

            // ✅ Apply global query filter for soft delete once on BaseEntity
            modelBuilder.Entity<BaseEntity>().HasQueryFilter(e => !e.IsDeleted);

            // Relationships
            modelBuilder.Entity<MenuItem>()
                .HasOne(m => m.Category)
                .WithMany(c => c.MenuItems)
                .HasForeignKey(m => m.CategoryId);

            modelBuilder.Entity<Order>()
                .HasMany(o => o.Items)
                .WithOne()
                .HasForeignKey(oi => oi.MenuItemId);
        }
    }
}
