using CookCraft.Repositories.Entities;
using Microsoft.EntityFrameworkCore;

namespace CookCraft.Repositories
{
    public class CookCraftDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }

        public CookCraftDbContext(DbContextOptions<CookCraftDbContext> options) : base(options)
        {

        }
    }
}
