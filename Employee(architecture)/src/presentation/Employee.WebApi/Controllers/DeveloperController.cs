using AutoMapper;
using EmployeeAPI.Application.Dtos;
using EmployeeAPI.Data.Contexts;
using EmployeeAPI.Domain.Entities;
using EmployeeAPI.Repositories.Developers;
using EmployeeAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAPI.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]    
    public class DeveloperController : ControllerBase
    {
        
        private readonly IDeveloperRepository _repository;        
        private readonly ILogger<DeveloperController> _logger;
        private readonly IWebHostEnvironment _env;

        public DeveloperController(
            IWebHostEnvironment env,
            IDeveloperRepository repository,
            ILogger<DeveloperController> logger
            )
        {
            _env = env;
            _repository = repository;             
            _logger = logger;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult GetDevelopers()
        {
            _logger.LogInformation("Getting all Developers");            
            var allDevelopers = _repository.GetAllDevelopers();
            
            return Ok(allDevelopers);
        }

        //[Authorize]
        [HttpGet("get-developer-by-id/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult GetDeveloperById(int id)
        {
            var developer = _repository.GetById(id);
            if (developer == null)
                return NotFound();
            return Ok(developer);
        }

        //[Authorize(Roles ="User")]
        [HttpPost("add-developer")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult AddDeveloper(DeveloperDTO developerDto)
        {
            if (developerDto != null)
            {
                try
                {
                    var developer = _repository.Create(developerDto);
                    return CreatedAtAction("GetDeveloperById", new { id = developer.DeveloperId }, developer);
                }
                catch (Exception e)
                {
                    return BadRequest($"{e.Message}, {e.StackTrace}");
                }
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Put(DeveloperDTO developerDTO)
        {
            _logger.LogInformation($"Put developer {developerDTO}");
            try
            {
                var response = _repository.Update( developerDTO);
                _logger.LogInformation($"Updated  developer successfully");
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }

            
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult Delete(int id)
        {
            _logger.LogInformation($"Deleting developer id={id}");
           
            var response = _repository.Delete(id);
            return Ok(response);
        }




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
                
                _logger.LogInformation($"Saving File {filename}");

                using (var stream = new FileStream(physicalPath, FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                }
                return new JsonResult(filename);

            }
            catch (Exception e)
            {
                _logger.LogInformation($"Exception {e.Message}");
                return new JsonResult("anonymous.png");
            }
        }
    }
}
