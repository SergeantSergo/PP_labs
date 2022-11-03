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
        [Required(ErrorMessage = "Kolvo is a required field.")]
        [Range(1, int.MinValue, ErrorMessage = "The quantity cannot be less than 1")]
        public int Kolvo { get; set; }
        [Required(ErrorMessage = "Date is a required field.")]
        public long Date { get; set; }
    }
}
