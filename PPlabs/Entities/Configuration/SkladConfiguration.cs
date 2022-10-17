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
    internal class SkladConfiguration : IEntityTypeConfiguration<Sklad>
    {
        public void Configure(EntityTypeBuilder<Sklad> builder)
        {
            builder.HasData
            (
            new Sklad
            {
                Id = new Guid("596ed4b0-e6ec-4165-9159-29c9e134a277"),
                SkladName = "UDyadiVani",
                
            },
            new Sklad
            {
                Id = new Guid("1278a0ea-941f-4b7a-b3e8-d2e9ab900407"),
                SkladName = "Octavia",

            }
        );
        }
    }
}
