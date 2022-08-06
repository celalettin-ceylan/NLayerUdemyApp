using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core.Model;

namespace NLayer.Repository.Seeds;

internal class ProductSeed : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasData(
            new Product() { Id = 1, CategoryId = 1, Price = 100, Stock = 20, CreatedDate = DateTime.Now , Name = "MOSO" },
            new Product() { Id = 2, CategoryId = 1, Price = 120, Stock = 20, CreatedDate = DateTime.Now, Name = "Faber" },
            new Product() { Id = 3, CategoryId = 2, Price = 120, Stock = 20, CreatedDate = DateTime.Now, Name = "Sefiller" },
            new Product() { Id = 4, CategoryId = 3, Price = 120, Stock = 20, CreatedDate = DateTime.Now, Name = "Kares" }
            );
    }
}
