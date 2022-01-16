using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MVCApi.Domain.Entites;

namespace MVCApi.Services
{
    public class EShopContext
        : IdentityDbContext<IdentityUser<Guid>, IdentityRole<Guid>, Guid>
    {
        public EShopContext(DbContextOptions<EShopContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; private set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; private set; }
        public DbSet<Customer> Customers { get; private set; }
        public DbSet<Category> Categories { get; private set; }
        public DbSet<ContactInfo> ContactInfos { get; private set; }
        public DbSet<Address> Addresses { get; private set; }
        public DbSet<Order> Orders { get; private set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>()
                .HasOne(x => (Customer)x.DomainUser);

            builder.Entity<ProductCart>()
                .HasKey(pc => new { pc.ProductId, pc.ShoppingCartId });

            builder.Entity<CurrencyProduct>()
                .HasKey(cp => new { cp.CurrencyId, cp.ProductId });

            builder.Entity<Currency>()
                .HasIndex(c => c.Code).IsUnique();

            builder.Entity<CurrencyProduct>()
                .Property(cp => cp.Value).HasPrecision(19, 4);
        }
    }
}