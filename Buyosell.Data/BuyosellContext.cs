using Microsoft.EntityFrameworkCore;
using Buyosell.Core.Models;
namespace Buyosell.Data
{
    public class BuyosellContext : DbContext
    {

        private const string _connectionString = @"Host=ec2-50-16-108-254.compute-1.amazonaws.com;Database=d73tuh4fkj2i9a;
                                                sslmode=Prefer;Trust Server Certificate=true; Port=5432;
                                                Username=ccaildkjuxcmft;Password=10456f6e6a9dedaebf5e19b10071994bed99c52bce7699ba19e6f8e9f7294444";

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseNpgsql(_connectionString);

        public DbSet<User> Users { get; set; }
        public DbSet<Ad> Ads { get; set; }
    }
}