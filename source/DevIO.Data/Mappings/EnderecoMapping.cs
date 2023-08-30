using AppMVCBasic1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevIO.Data.Mappings
{
    public class EnderecoMapping : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(p => p.Publicplace)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(p => p.Number)
                .IsRequired()
                .HasColumnType("varchar(50)");

                builder.Property(p => p.Cep)
                    .IsRequired()
                    .HasColumnType("varchar(8)");

                builder.Property(p => p.Complement)
                    .IsRequired()
                    .HasColumnType("varchar(250)");

                builder.Property(p => p.Neighborhood)
                    .IsRequired()
                    .HasColumnType("varchar(100)");

                builder.Property(p => p.City)
                    .IsRequired()
                    .HasColumnType("varchar(100)"); 

            builder.Property(p => p.State)
                    .IsRequired()
                    .HasColumnType("varchar(50)");

            builder.ToTable("Adresses");
        }
    }
}
