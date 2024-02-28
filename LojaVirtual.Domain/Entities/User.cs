using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaVirtual.Domain.Entities
{
    public sealed class User : IdentityUser <Guid>
    {
        protected User() { }

        public Cart Carts { get; set; }
    }
}
