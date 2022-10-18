using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string NameProduct { get; set; }
        public int Kolvo { get; set; }
        public Guid IDSklad { get; set; }
    }
}
