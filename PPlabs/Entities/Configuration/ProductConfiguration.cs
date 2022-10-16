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
                Id = new Guid("FA533662-E939-4F53-AA8B-5DB416FCF3C1"),
                NameProduct = "Burger",
                Kolvo = 120,
                IDSklad = new Guid("31BA897C-AEC8-4A9B-A95D-11AF407B821C"),

            },
            new Product
            {
                Id = new Guid("4C09DD5D-15D6-4C3C-9CBF-C810B496AA0E"),
                NameProduct = "fish",
                Kolvo = 20,
                IDSklad = new Guid("3AE0C0FD-5F60-4CE6-B33A-BA58AB5A63EB"),

            }
        );
        }
    }
}
