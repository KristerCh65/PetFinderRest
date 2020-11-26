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
        [ForeignKey("idPet")]
        public Pet pet { get; set; }


        [Required]
        public long ReportedBy { get; set; }
        [ForeignKey("idEntity")]
        public Entity entity { get; set; }

        public List<Pet> pets { get; set; }
        public List<Entity> entities { get; set; }

    }
}
