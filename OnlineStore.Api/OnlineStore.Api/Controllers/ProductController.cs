using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Api.Models;
using OnlineStore.Api.Services;

namespace OnlineStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("get-products") ]
        public IActionResult GetProducts()
        {
            var products = _productService.GetProducts();
            return Ok(products);
        }

        [HttpGet("get-product")]
        public IActionResult GetProduct( Guid id)
        {
            var product = _productService.GetProduct(id);
            return Ok(product);
        }

        [HttpPost("add-product")]
        public IActionResult AddProduct(Product product)
        {
            var newProduct = _productService.AddProduct(product);
            return Ok(newProduct);
        }

        [HttpPut("update-product")]
        public IActionResult UpdateProduct(Product product)
        {
            if(product == null || product.Id == Guid.Empty)
                return BadRequest();

            var updatedProduct = _productService.UpdateProduct(product);
            
            if(updatedProduct == null)
                return NotFound();
         
            return NoContent();
        }

    }
}
