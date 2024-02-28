﻿using LojaVirtual.Domain.Abstractions;
using LojaVirtual.Domain.Entities;
using LojaVirtual.Infrastructure.Context;
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
    }
}
