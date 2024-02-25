using Microsoft.EntityFrameworkCore;
using ProductStore.Domain.Entities;

namespace ProductStore.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        Database.Migrate();
    }
    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Seed data for Product
        modelBuilder.Entity<Product>().HasData(
            new Product { Id = Guid.NewGuid(), Name = "Iphone", Description = "Very Expensive" },
            new Product { Id = Guid.NewGuid(), Name = "Samsung", Description = "Not Expensive" },
            new Product { Id = Guid.NewGuid(), Name = "Nokia", Description = "Very Cheap" }

        );

    }

}

