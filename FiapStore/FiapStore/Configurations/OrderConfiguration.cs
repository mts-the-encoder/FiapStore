using FiapStore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FiapStore.Configurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("Order");
        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id)
            .HasColumnType("INT").ValueGeneratedNever().UseIdentityColumn();
        builder.Property(u => u.ProductName).HasColumnType("VARCHAR(100)");
        builder.HasOne(u => u.User)
            .WithMany(o => o.Orders)
            .HasPrincipalKey(o => o.Id);
    }
}