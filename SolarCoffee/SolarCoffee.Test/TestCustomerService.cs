using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using SolarCoffee.Data;
using SolarCoffee.Data.Models;
using SolarCoffee.Services.CustomerService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SolarCoffee.Test
{
    public class TestCustomerService
    {
        [Fact]
        public void CustomerService_GetsAllCustomers_GivenTheyExist()
        {
            var options = new DbContextOptionsBuilder<SolarDbContext>()
                .UseInMemoryDatabase("gets_all").Options;

            using var context = new SolarDbContext(options);

            var sut = new CustomerService(context);

            sut.CreateCustomer(new Data.Models.Customer
            {
                Id = 1232123,
                FirstName = "some",
                LastName = "some",
                CreatedOn = DateTime.Now,
                UpdatedOn = DateTime.Now,
            });
            sut.CreateCustomer(new Data.Models.Customer
            {
                Id = 23,
                FirstName = "some",
                LastName = "some",
                CreatedOn = DateTime.Now,
                UpdatedOn = DateTime.Now,
            });

            var allCustomers = sut.GetAllCustomers();

            allCustomers.Count.Should().Be(2);
        }
        [Fact]
        public void CustomerService_CreatesCustomers_GivenNewCustomerObject()
        {
            var options = new DbContextOptionsBuilder<SolarDbContext>()
                .UseInMemoryDatabase("Add_writes_to_database").Options;

            using var context = new SolarDbContext(options);
            var sut = new CustomerService(context);

            sut.CreateCustomer(new Data.Models.Customer
            {
                Id = 1232123,
                FirstName = "some",
                LastName = "some",
                CreatedOn = DateTime.Now,
                UpdatedOn = DateTime.Now,
            });
            context.Customers.Single().Id.Should().Be(1232123);
        }

        [Fact]
        public void CustomerService_DeleteCustomer_GivenId()
        {
            var options = new DbContextOptionsBuilder<SolarDbContext>()
                .UseInMemoryDatabase("Deletes_one").Options;

            using var context = new SolarDbContext(options);
            var sut = new CustomerService(context);
            sut.CreateCustomer(new Data.Models.Customer
            {
                Id = 1232123,
                FirstName = "some",
                LastName = "some",
                CreatedOn = DateTime.Now,
                UpdatedOn = DateTime.Now,
            });
            sut.DeleteCustomer(1232123);
            var allCustomers = sut.GetAllCustomers();
            allCustomers.Count.Should().Be(0) ;
        }

        [Fact]
        public void CustomerService_OrderByLastname_WhenGetAllCustomersInvoked()
        {
            // Arrange
            var data = new List<Customer>
            {
                new Customer
                {
                    Id = 1,
                    FirstName = "some",
                    LastName = "Zulu",
                    CreatedOn = DateTime.Now,
                    UpdatedOn = DateTime.Now,
                },
                new Customer
                {
                    Id = 2,
                    FirstName = "some",
                    LastName = "Alpha",
                    CreatedOn = DateTime.Now,
                    UpdatedOn = DateTime.Now,
                },
                new Customer
                {
                    Id = 3,
                    FirstName = "some",
                    LastName = "Xu",
                    CreatedOn = DateTime.Now,
                    UpdatedOn = DateTime.Now,
                }
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Customer>>();
            mockSet.As<IQueryable<Customer>>()
                .Setup(m => m.Provider)
                .Returns(data.Provider);

            mockSet.As<IQueryable<Customer>>()
                .Setup(m=>m.Expression)
                .Returns(data.Expression);

            mockSet.As<IQueryable<Customer>>()
                .Setup(m=>m.ElementType)
                .Returns(data.ElementType);
            
            mockSet.As<IQueryable<Customer>>()
                .Setup(m=>m.GetEnumerator())
                .Returns(data.GetEnumerator());

            var mockContext = new Mock<SolarDbContext>();

            mockContext.Setup(c => c.Customers)
                .Returns(mockSet.Object);

            // Act
            var sut = new CustomerService(mockContext.Object);
            var customers = sut.GetAllCustomers();

            //Assert
            customers.Count.Should().Be(3);
            customers[0].Id.Should().Be(2);
            customers[1].Id.Should().Be(3);
            customers[2].Id.Should().Be(1);

        }
    }
}
