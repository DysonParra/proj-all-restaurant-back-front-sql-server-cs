/*
 * @fileoverview    {RestaurantContext}
 *
 * @version         2.0
 *
 * @author          Dyson Arley Parra Tilano <dysontilano@gmail.com>
 *
 * @copyright       Dyson Parra
 * @see             github.com/DysonParra
 *
 * History
 * @version 1.0     Implementation done.
 * @version 2.0     Documentation added.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Project.Models;

namespace Restaurant.Data {

    /**
     * TODO: Description of {@code RestaurantContext}.
     *
     * @author Dyson Parra
     * @since .NET 8 (LTS), C# 12
     */
    public class RestaurantContext : DbContext {

        /**
         * TODO: Description of method {@code RestaurantContext}.
         *
         */
        public RestaurantContext(DbContextOptions<RestaurantContext> options)
            : base(options) {
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
