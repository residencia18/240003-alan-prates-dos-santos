using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using TechMed.Dommain.Entities;

namespace TechMed.Infrastructure.Configurations;

public class AtendimentoConfigurations : IEntityTypeConfiguration<Atendimento>
{
    public void Configure(EntityTypeBuilder<Atendimento> builder)
    {
        //Tabela configurations
        builder.ToTable("Atendimentos").HasKey(a => a.AtendimentoId);
        
        //collum type configurations
        builder.Property(a => a.SuspeitaInicial).HasColumnType("longtext");
        builder.Property(a => a.Diagnostico).HasColumnType("longtext");
     

        //Tables relacional
        builder
        .Property(a => a.MedicoId).IsRequired();
        builder
        .Property(a => a.PacienteId).IsRequired();
        
        //FK
        builder
        .HasOne(a => a.Medico).WithMany(a => a.Atendimentos).HasForeignKey(a => a.MedicoId);
        builder
        .HasOne(a => a.Paciente).WithMany(a => a.Atendimentos).HasForeignKey(a => a.PacienteId);

    }   
}