using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PetFinderApi.Models
{
    public class Pet
    {
        [Key]
        public long idPet { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string NamePet { get; set; }

        [Required]
        [Column(TypeName = "varchar(20)")]
        public string Specie { get; set; }

        [Column(TypeName = ("varchar(80)"))]
        public string Race { get; set; }

        public int Age { get; set; }

        public string Size { get; set; }

        public string Photo { get; set; }

    }
}
