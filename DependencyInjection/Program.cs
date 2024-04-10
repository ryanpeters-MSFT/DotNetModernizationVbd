using DependencyInjection.Repositories;
using DependencyInjection.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddSingleton<IOrderRepository, InMemoryOrderRepository>();
builder.Services.AddSingleton<OrderService>();

var app = builder.Build();

app.MapGet("/orders", (OrderService orderService) =>
{
    var orders = orderService.GetAllOrders();

    return Results.Ok(orders);
});

app.MapGet("/orders/{orderId}", (int orderId, OrderService orderService) =>
{
    var order = orderService.GetOrder(orderId);

    if (order != null)
    {
        return Results.Ok(order);
    }

    return Results.NotFound();
});

app.MapControllers();

app.Run();