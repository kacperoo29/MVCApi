using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MVCApi.Domain.Entites;
using Newtonsoft.Json.Converters;

namespace MVCApi.Services
{
    public class EShopContext : IdentityDbContext<IdentityUser<Guid>, IdentityRole<Guid>, Guid>
    {
        public DbSet<Product> Products { get; private set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; private set; }
        public DbSet<Customer> Customers { get; private set; }

        public EShopContext(DbContextOptions<EShopContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            // modelBuilder.Entity<ApplicationUser>()
            //     .HasOne<Customer>(e => (Customer)e.DomainUser)
            //     .WithOne(i => (ApplicationUser)i.ApplicationUser)
            //     .HasForeignKey<Customer>(c => c.ApplicationUserId);
            modelBuilder.Entity<Customer>()
                .HasOne<ApplicationUser>(u => (ApplicationUser)u.ApplicationUser)
                .WithOne(i => (Customer)i.DomainUser)
                .HasForeignKey<ApplicationUser>(c => c.DomainUserId);
        }
    }
}
