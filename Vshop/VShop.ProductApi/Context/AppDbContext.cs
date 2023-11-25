using Microsoft.EntityFrameworkCore;

namespace VShop.ProductApi;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; } 

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().HasKey(c => c.Id);
        modelBuilder.Entity<Category>().Property(c => c.Name).HasMaxLength(100).IsRequired();

        modelBuilder.Entity<Product>().HasKey(p => p.Id);
        modelBuilder.Entity<Product>().Property(p => p.Name).HasMaxLength(255).IsRequired();
        modelBuilder.Entity<Product>().Property(p => p.Price).HasColumnType("decimal(18,2)").IsRequired();
        modelBuilder.Entity<Product>().Property(p => p.Description).HasMaxLength(255).IsRequired();
        modelBuilder.Entity<Product>().Property(p => p.Stock).IsRequired();
        modelBuilder.Entity<Product>().Property(c => c.ImageURL).HasMaxLength(255).IsRequired();
        
        
        modelBuilder.Entity<Category>()
                    .HasMany(c => c.Products)
                    .WithOne(p => p.Category)
                    .IsRequired()
                    .HasForeignKey(p => p.CategoryId)
                    .OnDelete(DeleteBehavior.Cascade);
        
        modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Material Escolar" },
            new Category { Id = 2, Name = "Eletrônicos" }
        );
    }
}
