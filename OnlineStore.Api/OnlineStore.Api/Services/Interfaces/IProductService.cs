using System;
using OnlineStore.Api.Models;

namespace OnlineStore.Api.Services;

public interface IProductService
{
    List<Product> GetProducts();

    Product AddProduct(Product product);

    Product GetProduct(Guid id);

    Product UpdateProduct(Product product);
}
