using AutoMapper;
using EmployeeAPI.Application.Dtos;
using EmployeeAPI.Data.Contexts;
using EmployeeAPI.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAPI.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmployeeController : ControllerBase
    {
        private readonly IWebHostEnvironment _env;
        private readonly CompanyContext _context;
        private readonly IMapper _mapper;

        public EmployeeController(
            IWebHostEnvironment env,
            CompanyContext context,
            IMapper mapper)
        {
            _env = env;
            _context = context;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IEnumerable<EmployeeDTO>> Get()
        {
            var employees = _context.Employees.ToList();
            var employeesDto=_mapper.Map<IList<EmployeeDTO>>(employees);
            return Ok(employeesDto);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(long id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
                return NotFound();
            return Ok(employee);
        }
        [HttpPost]
        
        public async Task<ActionResult<Employee>> Post(EmployeeDTO empDto)
        {
            if (empDto != null)
            {
                var emp = _mapper.Map<Employee>(empDto);
                _context.Employees.Add(emp);
                await _context.SaveChangesAsync();
                //var employee =_context.Employees.FirstOrDefault(emp);
                //var result = _mapper.Map<EmployeeDTO>(employee);
                return CreatedAtAction("GetEmployee",new {id=emp.EmployeeId},emp);
            }
            else
            {
                return new JsonResult("Error");
            }
        }
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
