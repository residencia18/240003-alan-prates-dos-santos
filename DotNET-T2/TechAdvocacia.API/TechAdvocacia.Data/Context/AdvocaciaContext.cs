// TechAdvocacia.Data/Context/AdvocaciaContext.cs
using Microsoft.EntityFrameworkCore;
using TechAdvocacia.Core.Models;

public class AdvocaciaContext : DbContext
{
    public AdvocaciaContext(DbContextOptions<AdvocaciaContext> options)
        : base(options)
    {
    }

    public DbSet<Advogado> Advogados { get; set; }
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Documento> Documentos { get; set; }
    public DbSet<CasoJuridico> CasosJuridicos { get; set; }

    // Configurações adicionais do modelo
}
