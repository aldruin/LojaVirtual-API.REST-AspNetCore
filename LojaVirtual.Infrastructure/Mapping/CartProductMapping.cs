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
    public sealed class CartProductMapping : IEntityTypeConfiguration<CartProduct>
    {
        public void Configure(EntityTypeBuilder<CartProduct> builder)
        {
            builder.ToTable("CartProduct");

            builder.HasKey(cp => cp.Id)
                .HasName("PK_CartProduct");

            builder.Property(cp => cp.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("CartProductId")
                .HasColumnOrder(1)
                .HasComment("Primary key CartProduct");

            builder.Property(cp => cp.CartId)
                .IsRequired()
                .HasColumnName("CartId")
                .HasColumnOrder(2)
                .HasComment("Foreign key to Cart");

            builder.Property(cp => cp.ProductId)
                .IsRequired()
                .HasColumnName("ProductId")
                .HasColumnOrder(3)
                .HasComment("Foreign key to Product");

            builder.Property(cp => cp.Quantity)
                .IsRequired()
                .HasColumnName("Quantity")
                .HasColumnOrder(4)
                .HasComment("Quantity of Product in Cart");


            builder.HasOne(cp => cp.Cart)
                .WithMany(c => c.Products)
                .HasForeignKey(cp => cp.CartId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(cp => cp.Product)
                .WithMany()
                .HasForeignKey(cp => cp.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
