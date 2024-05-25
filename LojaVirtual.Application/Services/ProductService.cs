using LojaVirtual.Application.DataTransferObjects;
using LojaVirtual.Application.Interfaces;
using LojaVirtual.Application.Interfaces.Notifications;
using LojaVirtual.Application.Validators;
using LojaVirtual.Domain.Abstractions;
using LojaVirtual.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LojaVirtual.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly INotificationHandler _notificationHandler;

        public ProductService(IProductRepository productRepository, INotificationHandler notificationHandler)
        {
            _productRepository = productRepository;
            _notificationHandler = notificationHandler;
        }

        public async Task<ProductDto> CreateProductAsync(ProductDto productDto, ClaimsPrincipal user)
        {
            try
            {
                // obter usuario, validar role para criação de produtos..
                var validation = await new ProductValidator().ValidateAsync(productDto);
                if (!validation.IsValid)
                {
                    foreach (var error in validation.Errors)
                    {
                        _notificationHandler.AddNotification("InvalidProduct", error.ErrorMessage);
                        return null;
                    }
                }

                var product = new Product(productDto.Name, productDto.Price, productDto.Stock, productDto.Description) { };
                await _productRepository.AddAsync(product);
                _notificationHandler.AddNotification("ProductCreated", "Produto criado com sucesso");
                return new ProductDto(product.Name, product.Price, product.Stock, product.Description, product.Id) { };
            }
            catch (Exception ex)
            {
                _notificationHandler.AddNotification("ProductCreationFailed", $"Falha ao criar o produto: {ex.Message}");
                return null;

            }

        }

        public Task<ProductDto> GetAllProductsAsync(ClaimsPrincipal user)
        {
            throw new NotImplementedException();
        }

        public Task<ProductDto> GetProductAsync(Guid id, ClaimsPrincipal user)
        {
            throw new NotImplementedException();
        }

        public Task<ProductDto> RemoveProductAsync(Guid id, ClaimsPrincipal user)
        {
            throw new NotImplementedException();
        }

        public Task<ProductDto> UpdateProductAsync(ProductDto dto, ClaimsPrincipal user)
        {
            throw new NotImplementedException();
        }
    }
}
