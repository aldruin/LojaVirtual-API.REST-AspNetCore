using LojaVirtual.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaVirtual.Infrastructure.Context
{
    public class LojaVirtualDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public LojaVirtualDbContext(DbContextOptions<LojaVirtualDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartProduct> CartProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>()
            .HasOne(u => u.Cart)
            .WithOne(c => c.User)
            .HasForeignKey<Cart>(c => c.UserId);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(LojaVirtualDbContext).Assembly);
        }
    }
}
