﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SolarCoffee.Services.CustomerService;
using SolarCoffee.Services.OrderService;
using SolarCoffee.Web.Serialization;
using SolarCoffee.Web.ViewModels;

namespace SolarCoffee.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IOrderService _orderService;
        private readonly ICustomerService _customerService;
        public OrderController(ILogger<ProductController> logger, IOrderService orderService, ICustomerService customerService)
        {
            _logger = logger;
            _orderService = orderService;
            _customerService = customerService;
        }

        [HttpPost("/api/invoice")]
        public ActionResult GenerateNewOrder([FromBody]InvoiceModel invoice)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            _logger.LogInformation("Generation invoice");
            var order = OrderMapper.SerializeInvoiceToOrder(invoice);
            order.Customer=_customerService.GetById(invoice.CustomerId);
            var response = _orderService.GenerateInvoiceForOrder(order);
            //_orderService.GenerateOpenOrder(order);
            return Ok(response);
        }

        [HttpGet("/api/order")]
        public ActionResult GetOrders()
        {
            var orders = _orderService.GetOrders();
            var orderModels = OrderMapper.SerializingOrdersToViewModels(orders);
            return Ok(orderModels);
        }
        [HttpPatch("/api/order/complete/{id}")]
        public ActionResult MarkOrderComplete(int id)
        {
            _logger.LogInformation($"Marking order {id} complete...");
            _orderService.MarkFulfilled(id);
            return Ok();
        }


    }
}
