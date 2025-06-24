using System;

namespace OnlineStore.Api.Models;

public class Order
{
    public Guid Id { get; set; }
    public List<Product> Products { get; set; }
    public decimal Total { get; set; }
}
