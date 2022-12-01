using EmployeeAPI.Application.Dtos;
using EmployeeAPI.Projects.ProjectService;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeAPI.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectRepository _repository;
        public ProjectController(IProjectRepository repository)
        {
            _repository = repository;
        }


        [HttpGet]
        public ActionResult GetAll()
        {
            var projects = _repository.GetAll();
            return Ok(projects);
        }

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var project = _repository.GetById(id);
            if (project == null)
                return NotFound();
            return Ok(project);
        }

        [HttpPost]
        public ActionResult Add(ProjectDTO projectDTO)
        {
            if (ModelState.IsValid)
            {
                var project = _repository.Create(projectDTO);
                return CreatedAtAction(nameof(GetById),
                    new { id = project.ProjectId }, project);
            }
            return BadRequest();
        }

        [HttpPut]
        public ActionResult Put(ProjectDTO projectDTO)
        {
            var response = _repository.Update(projectDTO);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var response = _repository.Delete(id);
            return Ok(response);
        }
    }
}
