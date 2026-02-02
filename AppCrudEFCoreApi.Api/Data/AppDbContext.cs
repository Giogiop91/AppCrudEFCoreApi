using AppCrudEFCoreApi.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace AppCrudEFCoreApi.Api.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=localhost;Database=AppDB;User Id=appuser;Password=AppUser2026!;Encrypt=True;TrustServerCertificate=True;");
        }
    }
}
