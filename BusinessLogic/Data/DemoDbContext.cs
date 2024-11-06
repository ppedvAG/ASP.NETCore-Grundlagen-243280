using BusinessLogic.Models;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Data
{
    public class DemoDbContext : DbContext
    {
        public DbSet<Recipe> Recipes { get; set; }

        public DemoDbContext(DbContextOptions<DemoDbContext> options) : base(options)
        {            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            Seed.Instance.SeedData(modelBuilder);
        }
    }
}
