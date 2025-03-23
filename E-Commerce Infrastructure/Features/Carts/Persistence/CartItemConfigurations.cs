using E_Commerce_Domain.Entities.Carts;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace E_Commerce_Infrastructure.Features.Carts.Persistence
{
    public class CartItemConfigurationsL : IEntityTypeConfiguration<CartItem>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<CartItem> builder)
        {
            builder.HasKey(ci => new { ci.CartId, ci.ProductId });

            builder.HasOne(ci => ci.Cart)
                .WithMany(c => c.CartItems)
                .HasForeignKey(ci => ci.CartId);

            builder
               .HasOne(ci => ci.Product)
               .WithMany()
               .HasForeignKey(ci => ci.ProductId);

            builder.HasIndex(ci => ci.CartId);

            builder.HasIndex(ci => ci.ProductId);
        }
    }
}
