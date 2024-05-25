using LojaVirtual.Application.DataTransferObjects;
using LojaVirtual.Application.Interfaces;
using LojaVirtual.Application.Interfaces.Notifications;
using Microsoft.AspNetCore.Mvc;

namespace LojaVirtual.API.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;
    private readonly INotificationHandler _notificationHandler;

    public ProductController(IProductService productService, INotificationHandler notificationHandler)
    {
        _productService = productService;
        _notificationHandler = notificationHandler;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateProduct([FromBody] ProductDto dto)
    {
        var currentUser = HttpContext.User;
        var createdProduct = await _productService.CreateProductAsync(dto, currentUser);
        var notifications = _notificationHandler.GetNotifications();
        if (createdProduct != null)
        {
            var response = new { createdProduct, notifications };
            return Ok(response);
        }
        return BadRequest(notifications);
    }

    [HttpGet("get")]
    public async Task<IActionResult> GetProduct(Guid id)
    {
        var currentUser = HttpContext.User;
        var product = await _productService.GetProductAsync(id, currentUser);
        var notifications = _notificationHandler.GetNotifications();
        if (product != null)
        {
            var response = new { product, notifications };
            return Ok(response);
        }
        return BadRequest(notifications);
    }

    [HttpGet("getall")]
    public async Task<IActionResult> GetAllProducts()
    {
        var currentUser = HttpContext.User;
        var products = await _productService.GetAllProductsAsync(currentUser);
        var notifications = _notificationHandler.GetNotifications();
        if (products != null)
        {
            var response = new { products, notifications };
            return Ok(response);
        }
        return BadRequest(notifications);
    }

    [HttpPut("update")]
    public async Task<IActionResult> UpdateProduct(ProductDto dto)
    {
        var currentUser = HttpContext.User;
        var updatedProduct = await _productService.UpdateProductAsync(dto, currentUser);
        var notifications = _notificationHandler.GetNotifications();
        if (updatedProduct != null)
        {
            var response = new { updatedProduct, notifications };
            return Ok(response);
        }
        return BadRequest(notifications);
    }

    [HttpDelete("delete")]
    public async Task<IActionResult> DeleteProduct (Guid id)
    {
        var currentUser = HttpContext.User;
        var deletedProduct = await _productService.RemoveProductAsync(id, currentUser);
        var notifications = _notificationHandler.GetNotifications();
        if (deletedProduct != null)
        {
            var response = new { deletedProduct, notifications };
            return Ok(response);
        }
        return BadRequest(notifications);
    }
}
