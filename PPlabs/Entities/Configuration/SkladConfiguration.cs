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
                Id = Guid.NewGuid(),
                SkladName = "UDyadiVani",
                
            },
            new Sklad
            {
                Id = Guid.NewGuid(),
                SkladName = "Octavia",

            }
        );
        }
    }
}
