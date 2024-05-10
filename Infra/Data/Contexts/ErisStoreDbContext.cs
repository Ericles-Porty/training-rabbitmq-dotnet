using Eris.Rabbit.Store.Domain.Entities;
using Eris.Rabbit.Store.Infra.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Eris.Rabbit.Store.Infra.Data.Contexts;

public class ErisStoreDbContext : DbContext
{
    public ErisStoreDbContext() { }
    public ErisStoreDbContext(DbContextOptions<ErisStoreDbContext> options) : base(options) { }

    public DbSet<Product> Products { get; set; }
    public DbSet<Purchase> Purchases { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PurchaseConfiguration).Assembly);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.EnableSensitiveDataLogging();
    }
}