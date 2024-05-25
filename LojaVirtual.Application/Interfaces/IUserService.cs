using LojaVirtual.Application.DataTransferObjects;
using System.Security.Claims;

namespace LojaVirtual.Application.Interfaces;
public interface IUserService
{
    Task<UserDto> CreateUserAsync(UserDto userDto);
    Task<UserDto> GetUserAsync(ClaimsPrincipal user);
    Task<UserDto> UpdateUserAsync(ClaimsPrincipal user, UserDto userDto);
    Task<UserDto> DeleteUserAsync(ClaimsPrincipal user);
}