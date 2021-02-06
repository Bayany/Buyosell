using Microsoft.EntityFrameworkCore;
using Buyosell.Core.Models;
namespace Buyosell.Data
{
    public class BuyosellContext : DbContext
    {

        public BuyosellContext(DbContextOptions<BuyosellContext> options)
            : base(options){ }

        public DbSet<User> Users { get; set; }
        public DbSet<Ad> Ads { get; set; }
    }
}