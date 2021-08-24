using Apteka.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Apteka.API.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {             
        }

        public DbSet<Dori> Dorilar { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Dori>().HasData
                (
                    new Dori
                    {
                        Id = Guid.NewGuid(),
                        Name = "Sitromon",
                        Price = 1000,
                        Quantity = 100
                    },
                    new Dori
                    {
                        Id = Guid.NewGuid(),
                        Name = "Paratsetomol",
                        Price = 500,
                        Quantity = 50
                    }
                );
        }

    }
}
