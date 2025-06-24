using OnlineStore.Api.Models;

namespace OnlineStore.Api.Services;


public interface IOrderService
{
    Order CreateOrder(List<Product> products);

    Order GetOrder(Guid id);

    List<Order> GetOrders();
}
