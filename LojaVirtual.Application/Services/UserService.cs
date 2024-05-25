using LojaVirtual.Application.DataTransferObjects;
using LojaVirtual.Application.Interfaces;
using LojaVirtual.Domain.Entities;
using LojaVirtual.Application.Validators;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using LojaVirtual.Application.Interfaces.Notifications;

namespace LojaVirtual.Application.Services;
public sealed class UserService : IUserService
{
    private readonly UserManager<User> _userManager;
    private readonly INotificationHandler _notificationHandler;
    private readonly ICartService _cartService;

    public UserService(UserManager<User> userManager, INotificationHandler notificationHandler, ICartService cartService)
    {
        _userManager = userManager;
        _notificationHandler = notificationHandler;
        _cartService = cartService;
    }

    public async Task<UserDto> CreateUserAsync(UserDto dto)
    {
        var validationResult = await new UserValidator().ValidateAsync(dto);
        if (!validationResult.IsValid)
        {
            foreach (var error in validationResult.Errors)
            {
                _notificationHandler.AddNotification("InvalidUser", error.ErrorMessage);
            }
            return null;
        }

        var user = new User(dto.Email, dto.Name, dto.CPF) { };
        var result = await _userManager.CreateAsync(user, dto.Password);
        await _cartService.CreateCartAsync(user.Id);
        if (result.Succeeded)
        {
            _notificationHandler.AddNotification("UserCreated", "Usuario criado com sucesso.");
            return new UserDto(user.Id, user.Email, user.Name, user.CPF) {CartId = user.Cart.Id };
        }

        foreach (var error in result.Errors)
        {
            _notificationHandler.AddNotification("UserCreationFailed", $"Falha ao criar o usuario: {error.Description}");
        }
        return null;
    }

    public async Task<UserDto> DeleteUserAsync(ClaimsPrincipal user)
    {
        var currentUser = await _userManager.GetUserAsync(user);
        if (currentUser == null)
        {
            _notificationHandler.AddNotification("UserDeletionFailed", "O usuario nao pode ser encontrado para exclus�o.");
            return null;
        }

        var result = await _userManager.DeleteAsync(currentUser);
        if (result.Succeeded)
        {
            _notificationHandler.AddNotification("UserDeleted", "O usuario foi excluido com sucesso.");
            return new UserDto(currentUser.Id, currentUser.Name, currentUser.Email, currentUser.CPF);
        }

        foreach (var error in result.Errors)
        {
            _notificationHandler.AddNotification("UserDeletionFailed", $"Falha ao excluir o usuario: {error.Description}");
        }
        return null;
    }

    public async Task<UserDto> GetUserAsync(ClaimsPrincipal user)
    {
        var currentUser = await _userManager.GetUserAsync(user);
        if (currentUser == null)
        {
            _notificationHandler.AddNotification("UserNotFound", "O usuario nao pode ser encontrado.");
            return null;
        }

        return new UserDto(currentUser.Id, currentUser.Name, currentUser.Email, currentUser.CPF) { };
    }

    public async Task<UserDto> UpdateUserAsync(ClaimsPrincipal user, UserDto dto)
    {
        var validationResult = await new UserValidator().ValidateAsync(dto);
        if (!validationResult.IsValid)
        {
            foreach (var error in validationResult.Errors)
            {
                _notificationHandler.AddNotification("InvalidUser", error.ErrorMessage);
            }
            return null;
        }

        var currentUser = await _userManager.GetUserAsync(user);
        if (currentUser == null)
        {
            _notificationHandler.AddNotification("UserNotFound", "O usuario nao pode ser encontrado.");
            return null;
        }
        var updatedUser = new User() { Name = dto.Name, Email = dto.Email, Id = currentUser.Id };
        var result = await _userManager.UpdateAsync(updatedUser);
        if (result.Succeeded)
        {
            _notificationHandler.AddNotification("UserUpdated", "Os  dados de usuario foram atualizados com sucesso.");
            return new UserDto(updatedUser.Id, updatedUser.Name, updatedUser.Email, updatedUser.CPF);
        }
        foreach (var error in result.Errors)
        {
            _notificationHandler.AddNotification("UserUpdateFailed", $"Falha ao atualizar o usuario: {error.Description}");
        }
        return null;
    }
}
