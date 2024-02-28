using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaVirtual.Domain.Entities
{
    public sealed class Product : Entity
    {
        protected Product() { }

        public string Name{ get; set; }
        public decimal Value{ get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
    }
}
