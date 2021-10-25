using Microsoft.EntityFrameworkCore;
using MVCApi.Domain.Entites;

namespace MVCApi.Services
{
    public class EShopContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }

        public EShopContext(DbContextOptions<EShopContext> options)
            : base(options)
        {

        }

        // protected override void OnModelCreating(ModelBuilder modelBuilder) {
        //     modelBuilder.Entity<ShoppingCart>().HasMany(s => s.Products);
        // }
    }
}
