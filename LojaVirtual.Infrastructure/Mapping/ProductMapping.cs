using LojaVirtual.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaVirtual.Infrastructure.Mapping
{
    public sealed class ProductMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");

            builder.HasKey(p => p.Id)
            .HasName("PK_Product");

            builder.Property(p => p.Id)
            .ValueGeneratedOnAdd()
            .HasColumnName("ProductId")
            .HasColumnOrder(1)
            .HasComment("Primary key Product");

            builder.Property(p => p.Name)
            .IsRequired()
            .HasColumnOrder(2)
            .HasColumnName("ProductName")
            .HasColumnType("VARCHAR(100)")
            .HasComment("Name of Product");

            builder.Property(p => p.Price)
            .IsRequired()
            .HasColumnOrder(3)
            .HasColumnName("ProductPrice")
            .HasColumnType("DECIMAL(18,2)")
            .HasComment("Price of Product");

            builder.Property(p => p.Stock)
            .IsRequired()
            .HasColumnOrder(4)
            .HasColumnName("ProductStock")
            .HasColumnType("INT")
            .HasComment("Stock of Product");

            builder.Property(p => p.Description)
            .IsRequired()
            .HasColumnOrder(5)
            .HasColumnName("ProductDescription")
            .HasColumnType("VARCHAR(500)")
            .HasComment("Description of Product");
        }
    }
}
