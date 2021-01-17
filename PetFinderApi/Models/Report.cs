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
        public long id { get; set; }

        public DateTime RescueDate { get; set; }

        public long idPet { get; set; }
        [ForeignKey("idPet")]
        public Pet pet { get; set; }

        public long idEntity { get; set; }
        [ForeignKey("idEntity")]
        public Entity entity { get; set; }

    }
}
