using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public abstract class ProductForManipulationDto
    {
        [Required(ErrorMessage = "Employee name is a required field.")]
        [MaxLength(30, ErrorMessage = "Maximum length for the Name is 30 characters.")]
        public string NameProduct { get; set; }

        [Required(ErrorMessage = "Kolvo is a required field.")]
        [Range(1, int.MinValue, ErrorMessage = "The quantity cannot be less than 1")]
        public int Kolvo { get; set; }
    }
}
