using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaVirtual.Domain.Entities
{
    public sealed class User : IdentityUser<Guid>
    {
        public User(string userName, string email) : base(userName)
        {
            Email = email;
        }
        public Cart? Cart { get; set; }
    }
}
