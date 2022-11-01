using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Plan
    {
        [Column("PlanId")]
        public Guid Id { get; set; }
        [Required]
        [ForeignKey(nameof(Sklad1))]
        public Guid Sklad1 { get; set; }
        [Required]
        [ForeignKey(nameof(Sklad2))]
        public Guid Sklad2 { get; set; }
        [Required]
        [ForeignKey(nameof(Product))]
        public Guid Product { get; set; }
        [Required(ErrorMessage = "Company address is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for rhe Address is 60 characte")]
        public int Kolvo { get; set; }
        public long Date { get; set; }
        //
    }
}
