using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ResTIConnect.Domain.Entities;

namespace ResTIConnect.Infra.Data.Configurations
{
    public class SistemasConfigurations : IEntityTypeConfiguration<Sistemas>
    {
        public void Configure(EntityTypeBuilder<Sistemas> builder)
        {
            builder
            .ToTable("Sistemas")
            .HasKey(s => s.SistemaId);
            
            builder.HasMany(s => s.Users)
                .WithMany(u => u.Sistemas);

            builder.HasMany(s => s.Eventos)
                .WithMany(e => e.Sistemas);

        }
    }
}