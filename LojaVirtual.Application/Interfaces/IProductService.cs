using LojaVirtual.Application.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LojaVirtual.Application.Interfaces;
public interface IProductService
{
    Task<ProductDto> CreateProductAsync(ProductDto productDto, ClaimsPrincipal user);
    Task<ProductDto> GetProductAsync(Guid id, ClaimsPrincipal user);
    Task<ProductDto> GetAllProductsAsync(ClaimsPrincipal user);
    Task<ProductDto> UpdateProductAsync(ProductDto dto, ClaimsPrincipal user);
    Task<ProductDto> RemoveProductAsync(Guid id, ClaimsPrincipal user);
}
