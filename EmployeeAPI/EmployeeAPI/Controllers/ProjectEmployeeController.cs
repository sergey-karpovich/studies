using EmployeeAPI.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmployeeAPI.Models;

namespace EmployeeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectEmployeeController:Controller
    {
        private CompanyContext context;
        public ProjectEmployeeController(CompanyContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public JsonResult Get()
        {
            var table = context.Projects.Include(prop=>prop.ProjectsEmployees);
            return new JsonResult(table);
        }
        [HttpPut]
        public JsonResult Put(answer answer)
        {
            Project project = context.Set<Project>()
                .Include(s => s.ProjectsEmployees)
                .First(s => s.ProjectID == answer.Id);
            
            project.ProjectsEmployees = answer.pids.Select(pid =>
                new ProjectEmployeeJunction
                {
                    ProjectId = answer.Id,
                    EmployeeId = pid
                })
                .ToList();
            context.SaveChanges();
            return new JsonResult(project);
        }
    }
    public class answer
    {
        public long Id { get; set; }
        public long[] pids { get; set; }
    }
}
