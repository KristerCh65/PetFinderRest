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
        public DbSet<Pet> pets { get; set; }
        public DbSet<Entity> entities { get; set; }
        public DbSet<Report> reports { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder option)
        {
            option.UseSqlServer(@"Server=DESKTOP-G8TQAN1;Database=PetFinderDB;Trusted_Connection=true;");
        }

    }
}
