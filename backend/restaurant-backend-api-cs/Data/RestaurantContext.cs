using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Project.Models;

namespace Restaurant.Data
{
    public class RestaurantContext : DbContext
    {
        public RestaurantContext (DbContextOptions<RestaurantContext> options)
            : base(options)
        {
        }

        public DbSet<Project.Models.Chef> Chef { get; set; } = default!;

        public DbSet<Project.Models.Customer> Customer { get; set; }

        public DbSet<Project.Models.Ingredient> Ingredient { get; set; }

        public DbSet<Project.Models.Meal> Meal { get; set; }

        public DbSet<Project.Models.Order> Order { get; set; }

        public DbSet<Project.Models.Provider> Provider { get; set; }

        public DbSet<Project.Models.Supplier> Supplier { get; set; }

        public DbSet<Project.Models.Waiter> Waiter { get; set; }
    }
}
