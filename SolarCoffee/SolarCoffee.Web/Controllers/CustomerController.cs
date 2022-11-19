﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SolarCoffee.Services.CustomerService;
using SolarCoffee.Web.Serialization;
using SolarCoffee.Web.ViewModels;
using System.Linq;

namespace SolarCoffee.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly ICustomerService _customerService;

        public CustomerController(ILogger<CustomerController> logger, ICustomerService customerService)
        {
            _logger = logger;
            _customerService = customerService;
        }

        [HttpPost("/api/customer")]
        public ActionResult CreateCustomer([FromBody] CustomerModel customer)
        {
            _logger.LogInformation("Creating a new customer");
            customer.CreatedOn = DateTime.UtcNow;
            customer.UpdatedOn = DateTime.UtcNow;
            var customerData = CustomerMapper.SerializeCustomer(customer);
            var newCustomer = _customerService.CreateCustomer(customerData);
            return Ok(newCustomer);
        }

        [HttpGet("/api/customer")]
        public ActionResult GetCustomers()
        {
            _logger.LogInformation("Getting customers");
            var customers = _customerService.GetAllCustomers();
            var customerModels = customers.Select(customer => new CustomerModel
            {
                Id=customer.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                PrimaryAddress = AddressMapper.MapCustomerAddress(customer.PrimaryAddress),
                CreatedOn = customer.CreatedOn,
                UpdatedOn = customer.UpdatedOn,
            })
            .OrderByDescending(customer =>customer.CreatedOn)
            .ToList();
            return Ok(customerModels);
        }

        [HttpDelete("/api/customer/{id}")]
        public ActionResult DeleteCustomer(int id)
        {
            _logger.LogInformation("Deleting customer");
            var response = _customerService.DeleteCustomer(id);
            return Ok(response);
        }
    }
}