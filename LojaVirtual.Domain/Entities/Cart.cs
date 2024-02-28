﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaVirtual.Domain.Entities
{
    public sealed class Cart : Entity
    {
        protected Cart() { }

        public Guid UserId { get; set; }
        public ICollection<CartProduct> Products { get; set; }
    }
}
