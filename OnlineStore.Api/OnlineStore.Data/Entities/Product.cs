using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineStore.Data.Entities;

public class Product
{
    [Key]
    public Guid ProductId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string ImageUrl { get; set; }
    public int Quantity { get; set; }

    public ICollection<Order> Orders { get; set; } 
}
