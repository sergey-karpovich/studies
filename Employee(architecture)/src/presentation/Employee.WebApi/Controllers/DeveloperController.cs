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
    public class DeveloperController : ControllerBase
    {
        private readonly IWebHostEnvironment _env;
        private readonly DeveloperRepository _repository;        
        private readonly ILogger<DeveloperController> _logger;
       

        public DeveloperController(
            IWebHostEnvironment env,
            DeveloperRepository repository,
            ILogger<DeveloperController> logger
            )
        {
            _env = env;
            _repository=repository; 
            _logger = logger;
        }

        
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult Get()
        {
            //throw new Exception("This is an exception thrown from GetAllDeveloper");
            var allDevelopers = _repository.GetAllDevelopers();
           // var allDevelopersDTO = _mapper.Map<IList<DeveloperDTO>>(allDevelopers);
            return Ok(allDevelopers);
        }

        [Authorize]
        [HttpGet("get-developer-by-id/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult GetDeveloperById(int id)
        {
            var developer =  _repository.GetDeveloperById(id);
            if (developer == null)
                return NotFound();
            return Ok(developer);
        }

        [Authorize(Roles ="User")]
        [HttpPost("add-developer")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> AddDeveloper(DeveloperDTO developerDto)
        {
            if (developerDto != null)
            {
               var developer =  _repository.AddDeveloper(developerDto);
                return CreatedAtAction("GetDeveloperById", new { id = developer.Id }, developer);
            }
            else
            {
                return BadRequest();
            }
        }

        // Не работают!!!
        //[AllowAnonymous]
        //[HttpGet("get-developers-by-auftrag/{id}")]
        //public ActionResult GetDevelopersByAugtrag(int id)
        //{
        //    var developers = _repository.GetDevAuftrByAuftrag(id);
        //    return Ok(developers);
        //}
        //[AllowAnonymous]
        //[HttpGet("get-developers-by-month/{month}")]
        //public ActionResult GetDevelopersByAugtrag(DateTime month)
        //{
        //    var developers = _repository.GetDevAuftrByMonth(month);
        //    return Ok(developers);
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
