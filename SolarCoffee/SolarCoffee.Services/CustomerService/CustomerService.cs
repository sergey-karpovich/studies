using Microsoft.EntityFrameworkCore;
using SolarCoffee.Data;
using SolarCoffee.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarCoffee.Services.CustomerService
{
    public class CustomerService : ICustomerService
    {
        private readonly SolarDbContext _db;

        public CustomerService(SolarDbContext db)
        {
            _db = db;
        }

        /// <summary>
        /// Adds a new Customer record
        /// </summary>
        /// <param name="customer"></param>
        /// <returns>ServiceResponse<Customer></returns>
        public ServiceResponse<Customer> CreateCustomer(Customer customer)
        {
            try
            {
                _db.Customers.Add(customer);
                _db.SaveChanges();
                return new ServiceResponse<Customer>
                {
                    IsSuccess = true,
                    Message = "New Customer added",
                    Time = DateTime.UtcNow,
                    Data = customer
                };
            }
            catch (Exception e)
            {
                return new ServiceResponse<Customer>
                {
                    IsSuccess = false,
                    Message = e.StackTrace,
                    Time = DateTime.UtcNow,
                    Data = customer
                };
            }
        }
        /// <summary>
        /// Deletes a customer record
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ServiceResponse<bool></returns>
        public ServiceResponse<bool> DeleteCustomer(int id)
        {
            var customer = _db.Customers.FirstOrDefault(x => x.Id == id);
            var now = DateTime.UtcNow;
            if (customer == null)
            {
                return new ServiceResponse<bool>
                {
                    Time = now,
                    IsSuccess = false,
                    Message = "Customer to delete not found",
                    Data = false
                };
            }
            try
            {
                _db.Customers.Remove(customer);
                _db.SaveChanges();
                return new ServiceResponse<bool>
                {
                    Time = now,
                    IsSuccess = true,
                    Message =  "Customer created!",
                    Data = true
                };
            } 
            catch(Exception e)
            {
                return new ServiceResponse<bool>
                {
                    Time = now,
                    IsSuccess = false,
                    Message = e.StackTrace,
                    Data = false
                };
            }
        }

        /// <summary>
        /// Returns a list of Customers from the database
        /// </summary>
        /// <returns></returns>
        public List<Customer> GetAllCustomers()
        {
            return _db.Customers
                .Include(customer => customer.PrimaryAddress)
                .OrderBy(customer => customer.LastName)
                .ToList();

        }
        /// <summary>
        /// Gets a customer record by primary key
        /// </summary>
        /// <param name="id">int customer primary key</param>
        /// <returns>Customer</returns>
        public Customer GetById(int id)
        {

            //return _db.Customers.FirstOrDefault(c=>c.Id==id);
            return _db.Customers.Find(id);
        }
    }
}
