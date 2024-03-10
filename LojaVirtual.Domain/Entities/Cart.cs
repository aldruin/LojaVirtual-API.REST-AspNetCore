using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaVirtual.Domain.Entities
{
    public sealed class Cart : Entity
    {
        public Cart(Guid userId)
        {
            UserId = userId;
        }

        public Guid UserId { get; set; }
        public User? User { get; set; }
        public List<CartProduct> Products { get; set; } = new List<CartProduct>();
    }
}
