using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PetFinderApi.Models
{
    public class Refuge
    {
        [Key]
        public long idRefuge { get; set; }

        [Required]
        [Column(TypeName = ("varchar(200)"))]
        public string NameRefuge { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        public bool Whatsapp { get; set; }

        public string WebPage { get; set; }

        public string Facebook { get; set; }

        public string Description { get; set; }

        public string Address { get; set; }

        public string Photo { get; set; }
    }
}
