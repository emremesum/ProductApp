using Microsoft.EntityFrameworkCore;
using ProductApp.DataAccess.Products;
using System.Reflection;
using ProductApp.DataAccess.Users;
using ProductApp.DataAccess.SupportForm;

namespace ProductApp.DataAccess;

public class ProductAppDbContext : DbContext
{
    public ProductAppDbContext(DbContextOptions<ProductAppDbContext> options) : base(options)
    {

    }
    public DbSet<Product> Products { get; set; } = default!;
    public DbSet<UserApp> Users { get; set; } = default!;
    public DbSet<ContactForm> ContactForms { get; set; } = default!;



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        modelBuilder.Entity<UserApp>().HasData(new UserApp
        {
            Id = 1,
            Username = "Admin",
            Password = "Admin",
            Role = "Admin",
            IsDeleted = false
        });

        // ContactForm tablosu için örnek veriler
        modelBuilder.Entity<ContactForm>().HasData(
     new ContactForm
     {
         Id = 1,
         UserId = 1,
         Subject = "Ürün Sorgusu",
         Message = "X ürünü mevcut mu?",
         Status = "Beklemede",
         CreatedDate = DateTime.UtcNow,
         UpdatedDate = DateTime.UtcNow,
         IsDeleted = false
     },
     new ContactForm
     {
         Id = 2, // Farklı Id atanmış
         UserId = 1,
         Subject = "Sipariş Durumu",
         Message = "1234 numaralı siparişin durumu?",
         Status = "Çözüldü",
         CreatedDate = DateTime.UtcNow.AddDays(-5),
         UpdatedDate = DateTime.UtcNow,
         IsDeleted = false
     },
     new ContactForm
     {
         Id = 3, // Farklı Id atanmış
         UserId = 1,
         Subject = "Teknik Destek",
         Message = "Ürün kurulumunda yardıma ihtiyacım var.",
         Status = "Devam Ediyor",
         CreatedDate = DateTime.UtcNow.AddDays(-2),
         UpdatedDate = DateTime.UtcNow,
         IsDeleted = false
     }
 );

        // Product tablosu için örnek veriler
        modelBuilder.Entity<Product>().HasData(
            new Product
            {
                Id=1,
                Code = "P001",
                ProductName = "Kablosuz Klavye",
                Price = 29.99m,
                CreatedDate = DateTime.UtcNow,
                ImageUrl = "https://example.com/images/keyboard.png",
                IsDeleted = false
            },
            new Product
            {
                Id = 2,
                Code = "P002",
                ProductName = "Bluetooth Mouse",
                Price = 19.99m,
                CreatedDate = DateTime.UtcNow,
                ImageUrl = "https://example.com/images/mouse.png",
                IsDeleted = false
            }
        );





        base.OnModelCreating(modelBuilder);
    }

}
