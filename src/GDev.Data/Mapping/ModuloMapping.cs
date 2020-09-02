using GDev.Business.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GDev.Data.Mapping
{
    public class ModuloMapping : IEntityTypeConfiguration<Modulo>
    {
        public void Configure(EntityTypeBuilder<Modulo> builder)
        {
            builder.HasKey(m => m.Id);

            builder.Property(m => m.Id)
                .HasColumnType("VARCHAR(50)");
                

            builder.Property(m => m.Descricao)
                .HasColumnType("VARCHAR(100)");

            builder.HasMany(m => m.Acessos)
                .WithOne(a => a.Modulo)
                .HasForeignKey(a => a.ModuloId);

            builder.ToTable("MODULO");
        }
    }
}
