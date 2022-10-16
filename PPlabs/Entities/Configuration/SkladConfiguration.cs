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
                Id = new Guid("31BA897C-AEC8-4A9B-A95D-11AF407B821C"),
                SkladName = "UDyadiVani",
                
            },
            new Sklad
            {
                Id = new Guid("3AE0C0FD-5F60-4CE6-B33A-BA58AB5A63EB"),
                SkladName = "Octavia",

            }
        );
        }
    }
}
