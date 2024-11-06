using Microsoft.EntityFrameworkCore;
using ProductApp.DataAccess.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp.DataAccess
{
    public class ProductAppDbContext:DbContext
    {
        public ProductAppDbContext(DbContextOptions<ProductAppDbContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }

    }
}
