using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public class PlanForUpdateDto
    {
        public string Name { get; set; }
        public int Kolvo { get; set; }
        public long Date { get; set; }

    }
}
