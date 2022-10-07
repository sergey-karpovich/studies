using EmployeeAPI.Models;
using EmployeeAPI.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;
        private IDataRepository repository;
        public EmployeeController(
            IConfiguration configuration,
            IWebHostEnvironment env,
            IDataRepository rep)
        {
            _configuration = configuration;
            _env = env;
            repository = rep;
        }

        [HttpGet]
        public JsonResult Get(string? title = null, int? reportsTo = null)
        {
            var table = repository.GetFilteredEmployee(title, reportsTo);
            return new JsonResult(table);

        }
        [HttpPost]
        public JsonResult Post(Employee emp)
        {
            if (emp != null)
            {
                repository.CreateEmployee(emp);
                return new JsonResult("Added Successfully");
            }
            else
            {
                return new JsonResult("Error");
            }
        }
        [HttpPut]
        public JsonResult Put(Employee newEmployee)
        {
            if (newEmployee != null)
            {
                var oldEmployee = repository.GetEmployee((long)newEmployee.EmployeeId);
               
                repository.UpdateEmployee(newEmployee, oldEmployee);
                return new JsonResult("Updated Successfully");
            }
            else
            {
                return new JsonResult("Error");
            }
        }
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        { 
            repository.DeleteEmployee(id);
            return new JsonResult("Deleted Successfully");
        }
    }
}
