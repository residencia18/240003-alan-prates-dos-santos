using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ResTIConnect.Domain.Entities;

namespace ResTIConnect.Infra.Data.Configurations
{
    public class EnderecosConfigurations : IEntityTypeConfiguration<Enderecos>
    {
        public void Configure(EntityTypeBuilder<Enderecos> builder)
        {
            builder
            .ToTable("Enderecos")
            .HasKey(e => e.EnderecoId);

            builder.Property(e => e.Logradouro)
                .IsRequired();

        }
    }
}