using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineStore.Data.Entities;

public class Order
{
    [Key]
    public Guid OrderId { get; set; }
    public decimal Total { get; set; }

    public ICollection<Product> Products { get; set; }
}
