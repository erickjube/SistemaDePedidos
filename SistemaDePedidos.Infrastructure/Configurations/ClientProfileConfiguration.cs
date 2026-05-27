using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaDePedidos.Domain.Entities;

namespace SistemaDePedidos.Infrastructure.Configurations;

public class ClientProfileConfiguration : IEntityTypeConfiguration<ClientProfile>
{
    public void Configure(EntityTypeBuilder<ClientProfile> builder)
    {
        builder.HasKey(cp => cp.id);

        builder.HasOne(cp => cp.User)
            .WithOne()
            .HasForeignKey<ClientProfile>(cp => cp.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(cp => cp.Cart)     
            .WithOne(c => c.ClientProfile)     
            .HasForeignKey<Cart>(c => c.ClientProfileId)     
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(cp => cp.Orders)
            .WithOne(o => o.ClientProfile)
            .HasForeignKey(o => o.ClientProfileId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
