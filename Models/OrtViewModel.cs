using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MedienkurseTest2.Models
{
    public class OrtViewModel
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        [Display(Name ="Ort")]
        public string Name { get; set; }
        [Required]
        [MaxLength(255)]
        public string Kanton { get; set; }
        [Required]
        public int PLZ { get; set; }

    }
}
