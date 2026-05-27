using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaDePedidos.Domain.Entities;

namespace SistemaDePedidos.Infrastructure.Configurations;

public class CartItemConfiguration : IEntityTypeConfiguration<CartItem>
{
    public void Configure(EntityTypeBuilder<CartItem> builder)
    {
        builder.HasKey(ci => ci.Id);

        builder.HasOne(c => c.Cart)
            .WithMany(ci => ci.Items)
            .HasForeignKey(ci => ci.CartId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(ci => ci.Product)    
            .WithMany()    
            .HasForeignKey(ci => ci.ProductId)    
            .OnDelete(DeleteBehavior.Restrict);

        // Garanti que um produto não seja adicionado mais de uma vez ao mesmo carrinho
        builder.HasIndex(ci => new { ci.CartId, ci.ProductId }).IsUnique();

        builder.Property(ci => ci.Quantity).IsRequired();
    }
}
