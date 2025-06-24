using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Api.Services;
using OnlineStore.Api.Models;

namespace OnlineStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IMyservice _myservice;

        private readonly IMyservice _myservice2;
        public OrderController(IOrderService orderService, IMyservice myservice, IMyservice myservice2)
        {
            _orderService = orderService;
            _myservice = myservice;
            _myservice2 = myservice2;
        }
                                                       
        [HttpGet("get-orders")]
        public IActionResult GetOrders()
        {
            var orders = _orderService.GetOrders();
            return Ok(orders);
        }

        [HttpGet("get-order")]
        public IActionResult GetOrder( Guid id)
        {
            var order = _orderService.GetOrder(id);
            return Ok(order);
        }

        [HttpPost("add-order")]
        public IActionResult AddOrder(List<Product> products)
        {
            var newOrder = _orderService.CreateOrder(products);
            return Ok(newOrder);
        }

        [HttpPost("increaseByOne")]
        public IActionResult IncreaseByOne()
        {
        //     _myservice.IncreseByOne();
        //    var answer = _myservice2.IncreseByOne();
 
            return Ok(_myservice.IncreseByOne());
        }

    }
}
