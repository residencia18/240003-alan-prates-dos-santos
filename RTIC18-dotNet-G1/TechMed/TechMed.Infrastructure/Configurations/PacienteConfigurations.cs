using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechMed.Dommain.Entities;

namespace TechMed.Infrastructure.Configurations;

public class PacienteConfigurations:IEntityTypeConfiguration<Paciente>
{
    public void Configure(EntityTypeBuilder<Paciente> builder)
    {
        builder
        .ToTable("Pacientes")
        .HasKey(p => p.PacienteId);

        builder.Property(p => p.PacienteId).IsUnicode();
        builder.Property(p => p.CPF).HasMaxLength(15).IsUnicode();

    }
    
}