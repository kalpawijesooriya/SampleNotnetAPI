using System;
using OnlineStore.Api.Models;

namespace OnlineStore.Api.Services;

public class OrderService : IOrderService
{
    private static List<Order> _orders = new List<Order>();
    public Order CreateOrder(List<Product> products)
    {
       var order = new Order
        {
            Id = Guid.NewGuid(),
            Products = products,
            Total = products.Sum(p => p.Price)
        };
        _orders.Add(order);
        return order;
    }

    public Order GetOrder(Guid id)
    {
        return _orders.FirstOrDefault(o => o.Id == id);
    }

    public List<Order> GetOrders()
    {
        return _orders;
    }
}
