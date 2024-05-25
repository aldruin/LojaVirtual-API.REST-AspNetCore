using LojaVirtual.Application.Interfaces;
using LojaVirtual.Application.Interfaces.Notifications;
using Microsoft.AspNetCore.Mvc;

namespace LojaVirtual.API.Controllers;
[ApiController]
[Route("api/[controller]")]
public class CartController : ControllerBase
{
    private readonly ICartService _cartService;
    private readonly INotificationHandler _notificationHandler;

    public CartController(ICartService cartService, INotificationHandler notificationHandler)
    {
        _cartService = cartService;
        _notificationHandler = notificationHandler;
    }

    [HttpGet("get")]
    public async Task<IActionResult> GetCart()
    {
        var currentUser = HttpContext.User;
        var cartDto = await _cartService.GetCartByUserIdAsync(currentUser);
        var notifications = _notificationHandler.GetNotifications();

        if (cartDto != null)
        {
            var response = new { cartDto, notifications };
            return Ok(response);
        }
        return BadRequest(notifications);
    }
}
