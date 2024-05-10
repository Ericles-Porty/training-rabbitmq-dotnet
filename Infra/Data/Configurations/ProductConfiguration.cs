using Eris.Rabbit.Store.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eris.Rabbit.Store.Infra.Data.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        // Nome da tabela
        builder.ToTable("Products");

        // Chave primária
        builder.HasKey(p => p.Id);

        // Configuração das propriedades
        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(255); // Defina o tamanho máximo conforme necessário

        builder.Property(p => p.Price)
            .IsRequired();

        builder.Property(p => p.Description)
            .HasMaxLength(1000); // Defina o tamanho máximo conforme necessário

        builder.Property(p => p.Stock)
            .IsRequired();

        builder.Property(p => p.IsFeatured)
            .IsRequired();

        builder.Property(p => p.CreatedAt)
            .IsRequired()
            .HasDefaultValueSql("GETDATE()"); // Configura o valor padrão como a data atual

        builder.Property(p => p.UpdatedAt).IsRequired(false);

        // Relacionamento com a entidade Purchase
        builder.HasMany(p => p.Purchases)
            .WithOne(purchase => purchase.Product)
            .HasForeignKey(purchase => purchase.ProductId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}