using Microsoft.AspNetCore.Mvc;
using LojaVirtual.Application.Services;
using LojaVirtual.Application.DataTransferObjects;
using System.Threading.Tasks;
using LojaVirtual.Application.Interfaces;
using LojaVirtual.Application.Interfaces.Notifications;

namespace LojaVirtual.Application.Controllers;
[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly INotificationHandler _notificationHandler;

    public UserController(IUserService userService, INotificationHandler notificationHandler)
    {
        _userService = userService;
        _notificationHandler = notificationHandler;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateUser([FromBody] UserDto dto)
    {
        var createdUser = await _userService.CreateUserAsync(dto);
        var notifications = _notificationHandler.GetNotifications();
        if (createdUser != null)
        {
            var response = new { createdUser, notifications };
            return Ok(response);
        }
        return BadRequest(notifications);
    }

    //[Authorize]
    [HttpGet("get")]
    public async Task<IActionResult> GetUser()
    {
        var currentUser = HttpContext.User;
        var userDto = await _userService.GetUserAsync(currentUser);
        var notifications = _notificationHandler.GetNotifications();

        if (userDto != null)
        {
            var response = new { userDto, notifications };
            return Ok(response);
        }

        return BadRequest(notifications);
    }

    //[Authorize]
    [HttpPut("update")]
    public async Task<IActionResult> UpdateUser([FromBody] UserDto dto)
    {
        var currentUser = HttpContext.User;
        var updatedUserDto = await _userService.UpdateUserAsync(currentUser, dto);
        var notifications = _notificationHandler.GetNotifications();

        if (updatedUserDto != null)
        {
            var response = new { updatedUserDto, notifications };
            return Ok(response);
        }
        return BadRequest(notifications);
    }

    //[Authorize]
    [HttpDelete("delete")]
    public async Task<IActionResult> DeleteUser()
    {
        var currentUser = HttpContext.User;
        var deletedUser = await _userService.DeleteUserAsync(currentUser);
        var notifications = _notificationHandler.GetNotifications();
        if (deletedUser != null)
        {
            var response = new { deletedUser, notifications };
            return Ok(response);
        }
        return BadRequest(notifications);
    }
}
