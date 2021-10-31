using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MVCApi.Domain.Entites;

namespace MVCApi.Services
{
    public class EShopContext : IdentityDbContext<IdentityUser<Guid>, IdentityRole<Guid>, Guid>
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>()
                .HasOne(x => (Customer) x.DomainUser);
        }
    }
}