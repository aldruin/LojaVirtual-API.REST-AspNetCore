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
    public sealed class CartMapping : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.ToTable("Cart");

            builder.HasKey(c => c.Id)
                .HasName("PK_Cart");

            builder.Property(c => c.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("CartId")
                .HasColumnOrder(1)
                .HasComment("Primary key Cart");

            builder.Property(c => c.UserId)
                .IsRequired()
                .HasColumnName("UserId")
                .HasColumnOrder(2)
                .HasComment("Foreign key to User");

            builder.HasOne(c => c.User)
                .WithOne(u => u.Cart)
                .HasForeignKey<Cart>(c => c.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
