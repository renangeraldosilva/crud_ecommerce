using ECommerceSite.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerceSite.API.Persistence
{
    public class ECommerceDbContext : DbContext
    {
        public ECommerceDbContext(DbContextOptions<ECommerceDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }

       
    }
}
