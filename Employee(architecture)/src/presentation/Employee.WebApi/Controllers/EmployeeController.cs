using EmployeeAPI.Data.Contexts;
using EmployeeAPI.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAPI.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IWebHostEnvironment _env;
        private readonly CompanyContext _context;

        public EmployeeController(
            IWebHostEnvironment env,
            CompanyContext context)
        {
            _env = env;
            _context = context;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Employee>> Get()
        {
            var table = _context.Employees.ToList();
            return Ok(table);
        }
        //[HttpPost]
        //public JsonResult Post(Employee emp)
        //{
        //    if (emp != null)
        //    {
        //        repository.CreateEmployee(emp);
        //        return new JsonResult(emp);
        //    }
        //    else
        //    {
        //        return new JsonResult("Error");
        //    }
        //}
        //[HttpPut]
        //public JsonResult Put(Employee newEmployee)
        //{
        //    if (newEmployee != null)
        //    {
        //        var oldEmployee = repository.GetEmployee((long)newEmployee.EmployeeId);

        //        repository.UpdateEmployee(newEmployee, oldEmployee);
        //        return new JsonResult("Updated Successfully");
        //    }
        //    else
        //    {
        //        return new JsonResult("Error");
        //    }
        //}
        //[HttpDelete("{id}")]
        //public JsonResult Delete(int id)
        //{
        //    repository.DeleteEmployee(id);
        //    return new JsonResult("Deleted Successfully");
        //}

        [Route("SaveFile")]
        [HttpPost]
        public JsonResult SaveFile()
        {
            try
            {
                var httpRequest = Request.Form;
                var postedFile = httpRequest.Files[0];
                string filename = postedFile.FileName;
                var physicalPath = _env.ContentRootPath + "/Photos/" + filename;

                using (var stream = new FileStream(physicalPath, FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                }
                return new JsonResult(filename);

            }
            catch (Exception)
            {

                return new JsonResult("anonymous.png");
            }
        }
    }
}
