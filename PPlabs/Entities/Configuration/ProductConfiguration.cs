using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Configuration
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData
            (
            new Product
            {
                Id = Guid.NewGuid(),
                NameProduct = "Burger",
                Kolvo = 120,
                IDSklad = Guid.NewGuid(),

            },
            new Product
            {
                Id = Guid.NewGuid(),
                NameProduct = "fish",
                Kolvo = 20,
                IDSklad = Guid.NewGuid(),

            }
        );
        }
    }
}
