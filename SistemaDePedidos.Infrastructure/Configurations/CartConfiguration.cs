using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaDePedidos.Domain.Entities;

namespace SistemaDePedidos.Infrastructure.Configurations;

public class CartConfiguration : IEntityTypeConfiguration<Cart>
{
    public void Configure(EntityTypeBuilder<Cart> builder)
    {
        builder.HasKey(c => c.Id);

        builder.HasIndex(c => c.ClientProfileId).IsUnique();
        builder.Property(c => c.TotalAmount).HasColumnType("decimal(18,2)").HasDefaultValue(0);

        builder.HasMany(c => c.Items)
            .WithOne(ci => ci.Cart)
            .HasForeignKey(c => c.CartId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
