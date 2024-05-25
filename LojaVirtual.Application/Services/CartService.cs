using LojaVirtual.Application.DataTransferObjects;
using LojaVirtual.Application.Interfaces;
using LojaVirtual.Application.Interfaces.Notifications;
using LojaVirtual.Application.Validators;
using LojaVirtual.Domain.Abstractions;
using LojaVirtual.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LojaVirtual.Application.Services;
public class CartService : ICartService
{
    private readonly ICartRepository _cartRepository;
    private readonly INotificationHandler _notificationHandler;

    public CartService(ICartRepository cartRepository, INotificationHandler notificationHandler)
    {
        _cartRepository = cartRepository;
        _notificationHandler = notificationHandler;
    }

    public async Task<CartDto> CreateCartAsync(Guid userId)
    {
        try
        {
            var cart = new Cart(userId) { };
            await _cartRepository.AddAsync(cart);
            _notificationHandler.AddNotification("CartCreated", "Carrinho criado com sucesso.");
            return new CartDto(cart.UserId, cart.Id) { };
        }
        catch (Exception ex)
        {
            _notificationHandler.AddNotification("CartCreationFailed", $"Falha ao criar o carrinho: {ex.Message}");
            return null;
        }
    }

    public async Task<CartDto> GetCartByUserIdAsync(ClaimsPrincipal user)
    {
        var userIdClaim = user.FindFirst(ClaimTypes.NameIdentifier);
        if (userIdClaim == null)
        {
            _notificationHandler.AddNotification("UserNotFound", "Nao foi possivel obter o usuario logado");
            return null;
        }

        var userId = Guid.Parse(userIdClaim.Value);
        var cart = await _cartRepository.GetCartByUserIdAsync(userId);
        if (cart == null)
        {
            _notificationHandler.AddNotification("CartNotFound", "O carrinho nao pode ser encontrado. UserID de Usuário inválido.");
            return null;
        }

        return new CartDto(cart.UserId, cart.Id) { Products = cart.Products };
    }
}