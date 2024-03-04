
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ResTIConnect.Domain.Entities;

namespace ResTIConnect.Infra.Data.Configurations
{
    public class EventosConfiguration : IEntityTypeConfiguration<Eventos>
    {
        public void Configure(EntityTypeBuilder<Eventos> builder)
        {
            builder
           .ToTable("Eventos")
           .HasKey(e => e.EventoId);

            builder.HasMany(e => e.Sistemas)
                .WithMany(s => s.Eventos);
        }
    }
}