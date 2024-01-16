using GallowSoft.Household.Domain.InventoryItem;
using GallowSoft.Household.Infrastructure.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace GallowSoft.Household.Infrastructure.Data;

public interface IApplicationDbContext
{
    DbSet<InventoryItem> InventoryItems { get; set; } // This is for the InventoryItems
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options), IApplicationDbContext
{
    // InventoryItemConfiguration mapping
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new InventoryItemConfiguration());
        // Add other configurations here
    }
    
    public DbSet<InventoryItem> InventoryItems { get; set; }
    
    
}

