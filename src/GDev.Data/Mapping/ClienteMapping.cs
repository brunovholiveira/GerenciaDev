using GDev.Business.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace GDev.Data.Mapping
{
    public class ClienteMapping : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnType("VARCHAR(50)");

            builder.Property(c => c.RazaoSocial)
                .HasColumnName("RAZAO_SOCIAL")
                .HasColumnType("VARCHAR(100)");

            builder.HasMany(c => c.Acessos)
                .WithOne(a => a.Cliente)
                .HasForeignKey(a => a.ClienteId);

            builder.ToTable("EMPRESA");
        }
    }
}
