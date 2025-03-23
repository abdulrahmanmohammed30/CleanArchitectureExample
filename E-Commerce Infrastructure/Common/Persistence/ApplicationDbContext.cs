using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using E_Commerce_Domain.Identity;
using E_Commerce_Domain.Entities.Order;
using E_Commerce_Domain.Entities.Carts;
using E_Commerce_Domain.Entities.Products;
using E_Commerce_Application.Common.interfaces;
using E_Commerce_Infrastructure.Features.Products.Persistence;

namespace E_Commerce_Infrastructure.Common.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, string>, IUnitOfWork
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        public async Task CommitChangesAsync()
        {
            await SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductConfigurations).Assembly);
        }
    }
}
