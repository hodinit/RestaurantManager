using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RestaurantManager.Models;

namespace RestaurantManager.Data
{
    public class RestaurantManagerContext : DbContext
    {
        public RestaurantManagerContext (DbContextOptions<RestaurantManagerContext> options)
            : base(options)
        {
        }

        public DbSet<RestaurantManager.Models.Ingredient> Ingredient { get; set; } = default!;
        public DbSet<RestaurantManager.Models.MenuItem> MenuItem { get; set; } = default!;
        public DbSet<RestaurantManager.Models.Supplier> Supplier { get; set; } = default!;
        public DbSet<RestaurantManager.Models.Utensil> Utensil { get; set; } = default!;
        public DbSet<RestaurantManager.Models.Kitchen> Kitchen { get; set; } = default!;
        public DbSet<RestaurantManager.Models.Chef> Chef { get; set; } = default!;
    }
}
