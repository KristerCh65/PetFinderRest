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

        public FinderContext(DbContextOptions<FinderContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entity>().HasIndex(e => e.Email).IsUnique();
            modelBuilder.Entity<Entity>().HasIndex(e => e.UserName).IsUnique();
            modelBuilder.Entity<Entity>().HasIndex(e => e.Identification).IsUnique();
        }

    }
}
