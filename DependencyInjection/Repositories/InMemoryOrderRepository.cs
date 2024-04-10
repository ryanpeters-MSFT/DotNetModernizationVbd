using DependencyInjection.Models;

namespace DependencyInjection.Repositories;

public class InMemoryOrderRepository : IOrderRepository
{
    private static readonly ICollection<Order> _orders =
    [
        new Order
        {
            Id = 1,
            Name = "Ryan Peters",
            Items =
            [
                new Product { Id = 1, Name = "Surface Laptop", Price = 2099m },
                new Product { Id = 2, Name = "Zune", Price = 200m }
            ]
        },
        new Order
        {
            Id = 2,
            Name = "Anita Bath",
            Items =
            [
                new Product { Id = 3, Name = "Apple M3 Laptop", Price = 1599m },
                new Product { Id = 4, Name = "iPod", Price = 450m }
            ]
        }
    ];

    public ICollection<Order> GetAllOrders()
    {
        return _orders;
    }

    public Order CreateOrder(Order order)
    {
        order.Id = _orders.Max(o => o.Id) + 1;

        _orders.Add(order);

        return order;
    }
}