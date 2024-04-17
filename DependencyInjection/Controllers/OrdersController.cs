using DependencyInjection.Models;
using DependencyInjection.Services;
using Microsoft.AspNetCore.Mvc;

namespace DependencyInjection.Controllers;

[ApiController]
[Route("v2/[controller]")]
public class OrdersController(OrderService orderService) : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(orderService.GetAllOrders());
    }

    [HttpGet]
    [Route("{orderId}")]
    public IActionResult Get(int orderId)
    {
        var order = orderService.GetOrder(orderId);

        if (order != null)
        {
            return Ok(order);
        }

        return NotFound();
    }

    [HttpPost]
    public IActionResult Create(Order order, IConfiguration configuration)
    {
        var allowOrders = bool.Parse(configuration["Orders:EnableCreation"]);

        if (allowOrders) 
        {
            return Ok(orderService.CreateOrder(order));
        }

        return StatusCode(StatusCodes.Status403Forbidden, "Orders are currently disabled");
    }
}