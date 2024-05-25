using LojaVirtual.Application.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LojaVirtual.Application.Interfaces;
public interface ICartService
{
    Task<CartDto> CreateCartAsync(Guid userId);
    Task<CartDto> GetCartByUserIdAsync(ClaimsPrincipal user);
}
