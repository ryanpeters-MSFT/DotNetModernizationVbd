namespace DependencyInjection.Models;

public class Order
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<Product> Items { get; set; } = [];
    public DateTime Date { get; set; } = DateTime.Now;
}
