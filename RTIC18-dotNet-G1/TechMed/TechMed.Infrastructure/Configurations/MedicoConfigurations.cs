using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechMed.Dommain.Entities;

namespace TechMed.Infrastructure.Configurations;

public class MedicoConfigurations : IEntityTypeConfiguration<Medico>
{
    public void Configure(EntityTypeBuilder<Medico> builder)
    {
        builder
        .ToTable("Medicos")
        .HasKey(m => m.MedicoId);

        builder
        .Property(m => m.Nome).HasColumnType("longtext");
        builder
        .Property(m => m.MedicoId).IsUnicode();

        builder
        .Property(m => m.CPF).HasMaxLength(15).IsUnicode();
        
        builder
       .Property(m => m.CRM).HasMaxLength(15).IsUnicode();
    }
}