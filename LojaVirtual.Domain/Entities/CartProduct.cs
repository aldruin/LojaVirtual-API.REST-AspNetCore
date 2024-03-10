using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaVirtual.Domain.Entities
{
    public sealed class CartProduct : Entity
    {
        public CartProduct(Guid cartId, Guid productId, int quantity)
        {
            CartId = cartId;
            ProductId = productId;
            Quantity = quantity;
        }
        public Guid CartId { get; set; }
        public Cart? Cart { get; set; }
        public Guid ProductId { get; set; }
        public Product? Product { get; set; }
        public int Quantity { get; set; }
    }
}
