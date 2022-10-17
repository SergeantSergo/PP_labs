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
                Id = new Guid("231442f9-3ac9-4431-914c-6954adef1779"),
                NameProduct = "Burger",
                Kolvo = 120,
                IDSklad = new Guid("596ed4b0-e6ec-4165-9159-29c9e134a277"),

            },
            new Product
            {
                Id = new Guid("6ad5696d-aaf8-4be3-95ff-4590d7b55133"),
                NameProduct = "fish",
                Kolvo = 20,
                IDSklad = new Guid("1278a0ea-941f-4b7a-b3e8-d2e9ab900407"),

            }
        );
        }
    }
}
