using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaDePedidos.Domain.Entities;

namespace SistemaDePedidos.Infrastructure.Configurations;

public class SellerProfileConfiguration : IEntityTypeConfiguration<SellerProfile>
{
    public void Configure(EntityTypeBuilder<SellerProfile> builder)
    {
        builder.HasKey(sp => sp.Id);

        builder.HasOne(sp => sp.User)
            .WithOne()
            .HasForeignKey<SellerProfile>(sp => sp.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(sp => sp.Products)
            .WithOne(p => p.SellerProfile)
            .HasForeignKey(p => p.SellerProfileId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
