using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ResTIConnect.Domain.Entities;
namespace ResTIConnect.Infra.Data.Context
{
    public class ResTIConnectContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Perfis> Perfis { get; set; }
        public DbSet<Enderecos> Enderecos { get; set; }
        public DbSet<Eventos> Eventos { get; set; }
        public DbSet<Sistemas> Sistemas { get; set; }

        public ResTIConnectContext(DbContextOptions<ResTIConnectContext> options) : base(options)
        {
            //Database.EnsureCreated();
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ResTIConnectContext).Assembly);
        }
    }
}
