using Microsoft.EntityFrameworkCore;
using PetFinderApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetFinderApi.Data
{
    public class FinderContext : DbContext
    {
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Entity> Entities { get; set; }
        public DbSet<Report> Reports { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder option)
        {
            option.UseSqlServer(@"Server=DESKTOP-0S6O742;Database=PetFinderDB;Trusted_Connection=true;");
        }

    }
}
