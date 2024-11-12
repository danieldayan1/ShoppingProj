using Microsoft.EntityFrameworkCore;
using shoppingWebBackend.Data;
using shoppingWebBackend.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {
    }

    public DbSet<CategoryModel> Categories { get; set; }
    public DbSet<ProductModel> Products { get; set; }
    public DbSet<ChartModel> Charts { get; set; }
    public DbSet<ChartItemsModel> ChartProducts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<CategoryModel>().ToTable("Category");
        modelBuilder.Entity<ChartItemsModel>().ToTable("Chart_Products");
        modelBuilder.Entity<ChartModel>().ToTable("Chart");
        modelBuilder.Entity<ProductModel>().ToTable("Product");

        // Define the many-to-many relationship between Cart and Product
        modelBuilder.Entity<ChartItemsModel>()
            .HasKey(cp => cp.list_id);

        modelBuilder.Entity<ChartItemsModel>()
            .HasOne(cp => cp.Chart)
            .WithMany(c => c.ChartProducts)
            .HasForeignKey(cp => cp.chart_id);

        modelBuilder.Entity<ChartItemsModel>()
            .HasOne(cp => cp.Product)
            .WithMany(p => p.ChartProducts)
            .HasForeignKey(cp => cp.product_id);

        modelBuilder.Entity<CategoryModel>().HasKey(cp => cp.Id);
        modelBuilder.Entity<ChartModel>().HasKey(cp => cp.chart_id);
        modelBuilder.Entity<ProductModel>().HasKey(cp => cp.product_id);
        modelBuilder.Entity<ProductModel>().HasOne(cp => cp.Category).WithMany(cp => cp.Products).HasForeignKey(cp => cp.category_id);
    }
}
