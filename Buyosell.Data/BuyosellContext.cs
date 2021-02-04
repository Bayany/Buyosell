using Microsoft.EntityFrameworkCore;
using Buyosell.Core.Models;
namespace Buyosell.Data
{
    public class BuyosellContext : DbContext
    {

        private const string _connectionString = @"Host={your host};Database={your Database};
                                                sslmode=Prefer;Trust Server Certificate=true; Port={your port};
                                                Username={your username};Password={your password}";

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseNpgsql(_connectionString);

        public DbSet<User> Users { get; set; }
        public DbSet<Ad> Ads { get; set; }
    }
}