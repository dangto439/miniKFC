using Microsoft.EntityFrameworkCore;
using MiniKFCStore.Models;

namespace MiniKFCStore.Repositories
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasQueryFilter(u => !u.IsDeleted);
            modelBuilder.Entity<Category>().HasQueryFilter(c => !c.IsDeleted);
            modelBuilder.Entity<Product>().HasQueryFilter(p => !p.IsDeleted);
        }
    }
}
