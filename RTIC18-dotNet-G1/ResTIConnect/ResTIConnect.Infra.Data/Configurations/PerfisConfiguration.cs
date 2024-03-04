using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ResTIConnect.Domain.Entities;

namespace ResTIConnect.Infra.Data.Configurations
{
    public class PerfisConfiguration : IEntityTypeConfiguration<Perfis>
    {
        public void Configure(EntityTypeBuilder<Perfis> builder)
        {
            builder
           .ToTable("Perfis")
           .HasKey(p => p.PerfilId);

            builder.Property(e => e.Descricao)
                .IsRequired();

            builder.Property(e => e.Permissoes)
                .IsRequired();
        }
    }
}