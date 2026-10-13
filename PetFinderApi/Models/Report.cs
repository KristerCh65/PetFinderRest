using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PetFinderApi.Models
{
    public class Report
    {
        [Key]
        public long Case { get; set; }

        public DateTime RescueDate { get; set; }

        [Required]
        public long PetLost { get; set; }
        [ForeignKey(nameof(PetLost))]
        public Pet pet { get; set; }


        [Required]
        public long ReportedBy { get; set; }
        [ForeignKey(nameof(ReportedBy))]
        public Entity entity { get; set; }

    }
}
