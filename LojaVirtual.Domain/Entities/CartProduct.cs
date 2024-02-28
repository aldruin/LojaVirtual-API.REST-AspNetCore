using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaVirtual.Domain.Entities
{
    public sealed class CartProduct : Entity
    {
        protected CartProduct() { }

        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public Product? Product { get; set; }
    }
}
