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
    internal class PlanConfiguration : IEntityTypeConfiguration<Plan>
    {
        public void Configure(EntityTypeBuilder<Plan> builder)
        {
            builder.HasData
            (
            new Plan
            {
                Id = new Guid("407f07d3-7d13-4c04-9c69-50aac805def0"),
                Sklad1 = new Guid("407f07d3-7d13-4c04-9c69-50aac805def1"),
                Sklad2 = new Guid("407f07d3-7d13-4c04-9c69-50aac805def2"),
                Product = new Guid("407f07d3-7d13-4c04-9c69-50aac805def3"),
                Kolvo = 15,
                Date = 1662757200
            }
        );
        }
    }
}
