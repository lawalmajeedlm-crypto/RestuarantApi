using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RestaurantApi.Models;
using System;

namespace RestaurantApi.Data
{
    public static class DataSeeder
    {
        public static void Seed(RestaurantDbContext context)
        {
            // Apply migrations if needed
            context.Database.Migrate();
            var hasher = new PasswordHasher<User>();

            // Check if an Admin user already exists
            if (!context.Users.Any(u => u.Role == Role.Admin))
            {

                var admin = new User
                {
                    Id = Guid.NewGuid(),
                    Name = "Default Admin",
                    Email = "admin@restaurant.com",
                    Role = Role.Admin,
                    CreatedAt = DateTime.UtcNow,
                    CreatedBy = "System"
                };

                // Hash the default password
                admin.PasswordHash = hasher.HashPassword(admin, "Admin123!");

                context.Users.Add(admin);
              
            }
        
            // seed multiple rolesif you want test accounts
            if (!context.Users.Any(u => u.Role == Role.User))
            {
               var user = new User
                {
                    Id = Guid.NewGuid(),
                    Name = "Default User",
                    Email = "user@restaurant.com",
                    Role = Role.User,
                    CreatedAt = DateTime.UtcNow,
                    CreatedBy = "System"
                };

                user.PasswordHash = hasher.HashPassword(user, "User123!");
                context.Users.Add(user);
            }

            if (!context.Users.Any(u => u.Role == Role.Manager))
            {
                var manager = new User
                {
                    Id = Guid.NewGuid(),
                    Name = "Default Manager",
                    Email = "manager@restaurant.com",
                    Role = Role.Manager,
                    CreatedAt = DateTime.UtcNow,
                    CreatedBy = "System"
                };

                manager.PasswordHash = hasher.HashPassword(manager, "Manager123!");
                context.Users.Add(manager);
            }

            context.SaveChanges();
        }

    }
}

