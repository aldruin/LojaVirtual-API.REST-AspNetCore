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
        public User(string email, string name, string cpf)
        {
            Id = Guid.NewGuid();
            Email = email;
            Name = name;
            CPF = cpf;
            UserName = email;
        }
        public User() { }
        public Cart? Cart { get; set; }
        public string Name { get; set; }
        public string CPF { get; set; }
    }
}
