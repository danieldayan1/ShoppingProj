using Microsoft.EntityFrameworkCore;
using shoppingWebBackend.Data;
using shoppingWebBackend.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<CategoryModel> Categories { get; set; }
    public DbSet<ProductModel> Products { get; set; }
    public DbSet<ChartModel> Charts { get; set; }
    public DbSet<ChartItemsModel> ChartProducts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Define the many-to-many relationship between Cart and Product
        modelBuilder.Entity<ChartItemsModel>()
            .HasKey(cp => cp.Id);

        modelBuilder.Entity<ChartItemsModel>()
            .HasOne(cp => cp.Chart)
            .WithMany(c => c.ChartProducts)
            .HasForeignKey(cp => cp.ChartId);

        modelBuilder.Entity<ChartItemsModel>()
            .HasOne(cp => cp.Product)
            .WithMany(p => p.ChartProducts)
            .HasForeignKey(cp => cp.ProductId);
    }
}
