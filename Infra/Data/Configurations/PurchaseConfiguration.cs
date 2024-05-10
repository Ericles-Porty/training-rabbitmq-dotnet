
using Eris.Rabbit.Store.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eris.Rabbit.Store.Infra.Data.Configurations;

public class PurchaseConfiguration : IEntityTypeConfiguration<Purchase>
{
    public void Configure(EntityTypeBuilder<Purchase> builder)
    {
        builder.ToTable("Purchases");
        builder.HasKey(a => a.Id);
        builder.Property(a => a.Id).ValueGeneratedOnAdd();

        builder.Property(a => a.ProductId).IsRequired();
        builder.Property(a => a.Quantity).IsRequired();
        builder.Property(a => a.Total).IsRequired();
        builder.Property(a => a.Total).HasColumnType("decimal(10,2)");
        builder.Property(a => a.CreatedAt).IsRequired();

        builder.HasOne(a => a.Product)
            .WithMany(a => a.Purchases)
            .HasForeignKey(a => a.ProductId);
    }
}