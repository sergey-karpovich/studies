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
            var table = context.Projects
                .Include(prop => prop.Employees)                
                .ToArray(); 
            return new JsonResult(table);
        }
        [HttpPut]
        public JsonResult Put(answer answer)
        {
            Project project = context.Set<Project>()
                .Include(s => s.Employees)
                .First(s => s.ProjectID == answer.Id);
            List<Employee> employees = new List<Employee>(); 
            foreach(var id in answer.eids)
            {
                try
                {
                    Employee employee = context.Employees
                        .FirstOrDefault(e=>e.EmployeeId==id);
                    employees.Add(employee);
                } catch
                {
                    Console.WriteLine("Something went wrong");
                }
                
            }
            project.Employees = employees;

            //project.ProjectsEmployees = answer.eids.Select(eid =>
            //    new ProjectEmployeeJunction
            //    {
            //        ProjectId = answer.Id,
            //        EmployeeId = eid
            //    })
            //    .ToList();
            context.SaveChanges();
            return new JsonResult(project);
        }
    }
    public class answer
    {
        public long Id { get; set; }
        public long[] eids { get; set; }
    }
}
