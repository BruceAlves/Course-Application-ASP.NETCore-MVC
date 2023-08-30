using AppMVCBasic1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevIO.Data.Mappings
{
    public class FornecedorMapping : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(p => p.Name)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(p => p.Document)
                 .IsRequired()
                 .HasColumnType("varchar(14)");

            // configuration one : one => Suppliers in Addresss
            builder.HasOne(f => f.Address)
                .WithOne(e => e.Supplier);
            // configuration one : N => Supplier has several products

            builder.HasMany(f => f.Products)
                .WithOne(p => p.Supplier)
                .HasForeignKey(p => p.SupplierId);

            builder.ToTable("Suppliers");
        }
    }
}
