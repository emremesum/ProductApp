using Microsoft.EntityFrameworkCore;
using ProductApp.DataAccess.Products;
using System.Reflection;
using ProductApp.DataAccess.User;
using ProductApp.DataAccess.Users;

namespace ProductApp.DataAccess;

public class ProductAppDbContext:DbContext
{
    public ProductAppDbContext(DbContextOptions<ProductAppDbContext> options) : base(options)
    {

    }
    public DbSet<Product> Products { get; set; } = default!;
    public DbSet<UserApp> Users { get; set; } = default!;

		protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }

}
