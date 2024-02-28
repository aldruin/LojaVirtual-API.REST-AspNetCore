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
            builder.ToTable("CartProducts");
            builder.HasKey(cp => cp.Id);
            builder.Property(cp => cp.Id).ValueGeneratedOnAdd();
            builder.Property(cp => cp.Quantity).IsRequired();

            builder.HasOne(cp => cp.Product).WithMany().HasForeignKey(cp => cp.ProductId);
        }
    }
}
