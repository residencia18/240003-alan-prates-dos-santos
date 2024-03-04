using Microsoft.EntityFrameworkCore;
using TechMed.Dommain.Entities;

namespace TechMed.Infrastructure.Context;

public class TechMedContext : DbContext
{
     public TechMedContext(DbContextOptions<TechMedContext> options) : base(options){}
    public DbSet<Atendimento> Atendimentos { get; set; }
    public DbSet<Exame> Exames { get; set; }
    public DbSet<Medico> Medicos { get; set; }
    public DbSet<Paciente> Pacientes { get; set; }
  

    protected override void OnModelCreating(ModelBuilder modelBuilder){
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TechMedContext).Assembly);
    }
}