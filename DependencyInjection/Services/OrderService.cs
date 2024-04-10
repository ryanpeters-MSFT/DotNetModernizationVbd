using DependencyInjection.Models;
using DependencyInjection.Repositories;

namespace DependencyInjection.Services;

public class OrderService(IOrderRepository orderRepository)
{
    public ICollection<Order> GetAllOrders()
    {
        return orderRepository.GetAllOrders();
    }

    public Order GetOrder(int id)
    {
        return GetAllOrders().FirstOrDefault(o => o.Id == id);
    }

    public Order CreateOrder(Order order)
    {
        return orderRepository.CreateOrder(order);
    }
}