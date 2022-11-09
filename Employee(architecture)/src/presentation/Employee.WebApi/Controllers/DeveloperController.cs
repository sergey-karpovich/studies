using AutoMapper;
using EmployeeAPI.Application.Dtos;
using EmployeeAPI.Data.Contexts;
using EmployeeAPI.Domain.Entities;
using EmployeeAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAPI.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DeveloperController : ControllerBase
    {
        private readonly IWebHostEnvironment _env;
        private readonly DeveloperRepository _repository;
        private readonly IMapper _mapper;

        public DeveloperController(
            IWebHostEnvironment env,
            DeveloperRepository repository,
            IMapper mapper)
        {
            _env = env;
            _repository=repository;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult Get()
        {
            var allDevelopers = _repository.GetAllDevelopers();
           // var allDevelopersDTO = _mapper.Map<IList<DeveloperDTO>>(allDevelopers);
            return Ok(allDevelopers);
        }

        //[AllowAnonymous]
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Employee>> GetEmployee(long id)
        //{
        //    var employee = await _context.Employees.FindAsync(id);
        //    if (employee == null)
        //        return NotFound();
        //    return Ok(employee);
        //}
        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> Post(DeveloperDTO developerDto)
        {
            if (developerDto != null)
            {
               var developer = _repository.AddDeveloper(developerDto);
                return CreatedAtAction("GetDeveloper", new { id = developer.Id }, developer);
            }
            else
            {
                return BadRequest();
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
