﻿using SolarCoffee.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarCoffee.Services.CustomerService
{
    public interface ICustomerService
    {
        List<Customer> GetAllCustomers();
        ServiceResponse<Customer> CreateCustomer(Customer customer);
        ServiceResponse<bool> DeleteCustomer(int id);
        Customer GetById(int id);        
    }
}
