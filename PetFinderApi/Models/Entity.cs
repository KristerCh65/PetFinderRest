using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace PetFinderApi.Models
{
    public class Entity
    {
        [Key]
        public long idEntity { get; set; } 

        [Required]
        [Column(TypeName ="varchar(20)")]
        public string Identification { get; set; }

        public string auth0Id { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        [Column(TypeName = "varchar(200)")]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        public string LastName { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        public bool Whatsapp { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string Facebook { get; set; }

        public string Address { get; set; }

        public string Photo { get; set; }

    }
}
