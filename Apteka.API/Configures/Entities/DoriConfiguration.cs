using Apteka.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Apteka.API.Configures.Entities
{
    public class DoriConfiguration : IEntityTypeConfiguration<Dori>
    {
        public void Configure(EntityTypeBuilder<Dori> builder)
        {
            builder.HasData
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
