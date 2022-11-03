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
                Id = new Guid("407f07d3-7d13-4c04-9c69-50aac805def2"),
                Sklad1 = new Guid("596ed4b0-e6ec-4165-9159-29c9e134a277"),
                Sklad2 = new Guid("1278a0ea-941f-4b7a-b3e8-d2e9ab900407"),
                Product = new Guid("6ad5696d-aaf8-4be3-95ff-4590d7b55133"),
                Name = "Первый план",
                Kolvo = 15,
                Date = 1662757200
            }
        );
        }
    }
}
