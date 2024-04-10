using DependencyInjection.Models;

namespace DependencyInjection.Repositories;

public interface IOrderRepository
{
    ICollection<Order> GetAllOrders();
    Order CreateOrder(Order order);
}