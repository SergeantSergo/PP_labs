using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public abstract class PlanManipulationDto
    {
        [Required(ErrorMessage = "Plan name is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Name is 60 characters.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Kolvo is a required field.")]
        [Range(0, int.MaxValue, ErrorMessage = "The quantity cannot be less than 1")]
        public int Kolvo { get; set; }
        [Required(ErrorMessage = "Date is a required field.")]
        public long Date { get; set; }
    }
}
