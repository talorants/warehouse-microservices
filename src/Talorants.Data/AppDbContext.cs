using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Talorants.Data.Entities;

namespace Talorants.Data;

public class AppDbContext : DbContext
{
    public DbSet<Category>? Categories { get; set; }
    public DbSet<User>? Users { get; set; }
    public DbSet<Product>? Products { get; set; }
    public DbSet<Warehouse>? Warehouses { get; set; }
    public DbSet<UserGroup>? UserGroups { get; set; }
    public DbSet<ProductCategory>? ProductCategories { get; set; }
    public DbSet<UserWarehouse>? UserWarehouses { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        modelBuilder.Entity<ProductCategory>()
            .HasKey(pc => new { pc.ProductId, pc.CategoryName });
        modelBuilder.Entity<ProductCategory>()
            .HasOne(pc => pc.Product)
            .WithMany(p => p.ProductCategories)
            .HasForeignKey(pc => pc.ProductId);
        modelBuilder.Entity<ProductCategory>()
            .HasOne(pc => pc.Category)
            .WithMany(c => c.ProductCategories)
            .HasForeignKey(pc => pc.CategoryName);

        modelBuilder.Entity<Warehouse>()
            .HasMany(w => w.Products)
            .WithOne(p => p.Warehouse)
            .IsRequired()
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<UserWarehouse>()
            .HasKey(uw => new {uw.UserId, uw.WarehouseId});
        modelBuilder.Entity<UserWarehouse>()
            .HasOne(uw => uw.User)
            .WithMany(u => u.UserWarehouses)
            .HasForeignKey(uw => uw.UserId);
        modelBuilder.Entity<UserWarehouse>()
            .HasOne(uw => uw.Warehouse)
            .WithMany(w => w.UserWarehouses)
            .HasForeignKey(uw => uw.WarehouseId);

        modelBuilder.Entity<UserGroup>()
            .HasMany(ug => ug.Users)
            .WithOne(u => u.UserGroup)
            .IsRequired()
            .OnDelete(DeleteBehavior.SetNull);
    }

    public override int SaveChanges()
    {
        AddNameHash();
        SetDates();

        return base.SaveChanges();
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        AddNameHash();
        SetDates();

        return base.SaveChangesAsync(cancellationToken);
    }

    private void SetDates()
    {
        foreach (var entry in ChangeTracker.Entries<EntityBase>())
        {
            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreatedAt = DateTime.UtcNow;
                entry.Entity.UpdatedAt = DateTime.UtcNow;
            }

            if (entry.State == EntityState.Modified)
            {
                entry.Entity.UpdatedAt = DateTime.UtcNow;
            }
        }
    }

    private void AddNameHash()
    {
        foreach (var entry in ChangeTracker.Entries<User>())
        {
            if (entry.Entity is User user)
                user.NameHash = user?.Name?.ToLower().Sha256();
        }
    }
}
