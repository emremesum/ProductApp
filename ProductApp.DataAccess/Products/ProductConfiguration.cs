using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp.DataAccess.Products;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        //configure 

        builder.HasKey(x => x.Id);
        builder.Property(x => x.ProductName).IsRequired();
        builder.Property(x => x.Price).HasColumnType("decimal(10,2)");

    }
}
