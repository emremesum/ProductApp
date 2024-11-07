using Microsoft.EntityFrameworkCore;
using ProductApp.DataAccess.Products;
using System.Reflection;
using ProductApp.DataAccess.Users;
using ProductApp.DataAccess.SupportForm;

namespace ProductApp.DataAccess;

public class ProductAppDbContext:DbContext
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

        base.OnModelCreating(modelBuilder);
    }

}
