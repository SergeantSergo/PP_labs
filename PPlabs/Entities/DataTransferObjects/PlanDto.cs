using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public class PlanDto
    {
        public Guid Id { get; set; }
        public Guid Sklad1 { get; set; }
        public Guid Sklad2 { get; set; }
        public Guid Product { get; set; }
        public int Kolvo { get; set; }
        public long Date { get; set; }

    }
}
