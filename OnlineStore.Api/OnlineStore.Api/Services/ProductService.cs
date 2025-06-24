using System;
using OnlineStore.Api.Models;
using OnlineStore.Data;

namespace OnlineStore.Api.Services;

public class ProductService : IProductService
{
  
   // private static List<Product> products = new List<Product>();

    private readonly AppDbContext _context;
    public ProductService(AppDbContext context)
    {
      _context = context;
    }

    public Product AddProduct(Product product)
    {
        var dbProductModel = new Data.Entities.Product
        {
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            ImageUrl = product.ImageUrl,
            Quantity = product.Quantity
        };

        dbProductModel.ProductId = Guid.NewGuid();
        _context.Products.Add(dbProductModel);
        _context.SaveChanges();

        return product;
    }

    public Product GetProduct(Guid id)
    {
       return _context.Products
            .Select(p => new Product
            {
                Id = p.ProductId,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                ImageUrl = p.ImageUrl,
                Quantity = p.Quantity
            })
            .FirstOrDefault();
    }

    public List<Product> GetProducts()
    {

        var products = _context.Products.ToList();
        return products
            .Select(p => new Product
            {
                Id = p.ProductId,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                ImageUrl = p.ImageUrl,
                Quantity = p.Quantity
            })
            .ToList();
    }

    public Product UpdateProduct(Product product)
    {
       var exisitingProduct = _context.Products.FirstOrDefault(p => p.ProductId == product.Id);
         if(exisitingProduct == null)
         {
              return null;
         }
         else
        {
            exisitingProduct.Name = product.Name;
            exisitingProduct.Description = product.Description;
            exisitingProduct.Price = product.Price;
            exisitingProduct.ImageUrl = product.ImageUrl;
            exisitingProduct.Quantity = product.Quantity;

            _context.SaveChanges();
            return new Product
            {
                Id = exisitingProduct.ProductId,
                Name = exisitingProduct.Name,
                Description = exisitingProduct.Description,
                Price = exisitingProduct.Price,
                ImageUrl = exisitingProduct.ImageUrl,
                Quantity = exisitingProduct.Quantity
            };
        }

    }
}
