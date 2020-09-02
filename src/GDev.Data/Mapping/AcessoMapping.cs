using GDev.Business.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GDev.Data.Mapping
{
    public class AcessoMapping : IEntityTypeConfiguration<Acesso>
    {
        public void Configure(EntityTypeBuilder<Acesso> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Id)
                .HasColumnType("VARCHAR(50)");

            builder.Property(a => a.Url)
                .HasColumnName("URL")
                .HasColumnType("VARCHAR(100)");

            builder.Property(a => a.Token)
                .HasColumnName("TOKEN")
                .HasColumnType("VARCHAR(10)");

            builder.ToTable("ACESSO");
        }
    }
}
