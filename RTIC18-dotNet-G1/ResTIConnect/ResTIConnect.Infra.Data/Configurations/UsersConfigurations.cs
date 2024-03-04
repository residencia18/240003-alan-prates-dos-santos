using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ResTIConnect.Domain.Entities;
namespace ResTIConnect.Infra.Data.Configurations
{
    public class UsersConfigurations : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
            .ToTable("User")
            .HasKey(u => u.UserId);
            
            builder.HasOne(u => u.Endereco)
                .WithOne()
                .HasForeignKey<User>(u => u.EnderecoId)
                .IsRequired(false);

            builder.HasMany(u => u.Perfis)
                .WithMany(p => p.Users);

            builder.HasMany(u => u.Sistemas)
                .WithMany(s => s.Users);
        }
    }
}