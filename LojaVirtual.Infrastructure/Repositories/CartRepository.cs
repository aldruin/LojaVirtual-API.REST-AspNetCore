using LojaVirtual.Domain.Abstractions;
using LojaVirtual.Domain.Entities;
using LojaVirtual.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaVirtual.Infrastructure.Repositories
{
    public class CartRepository : Repository<Cart>, ICartRepository
    {
        public CartRepository(LojaVirtualDbContext context) : base(context)
        {
        }

        public async Task<Cart> GetCartByUserIdAsync(Guid userId)
        {
            var cart = await Query.Cast<Cart>().Where(c => c.UserId == userId).FirstOrDefaultAsync();
            return cart;
        }

    }
}
