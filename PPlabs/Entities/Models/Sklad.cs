using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Entities.Models
{
    public class Sklad
    {
        [Column("SkaldId")]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "SkladName name is a required field.")]
        [MaxLength(30, ErrorMessage = "Maximum length for the Name is 30 characters.")] 
        public string SkladName { get; set; }
        
    }
}
