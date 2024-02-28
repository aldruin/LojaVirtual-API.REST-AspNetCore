using LojaVirtual.Domain.Abstractions;
using LojaVirtual.Domain.Entities;
using LojaVirtual.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaVirtual.Infrastructure.Repositories
{
    public class CartProductRepository : Repository<CartProduct>, ICartProductRepository
    {
        public CartProductRepository(LojaVirtualDbContext context) : base(context)
        {
        }
    }
}
