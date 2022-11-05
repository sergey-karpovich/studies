
// using Microsoft.AspNetCore.Mvc;


// namespace Employee.WebApi.Controllers
// {
//     [Route("api/[controller]")]
//     [ApiController]
//     public class ProjectEmployeeController:Controller
//     {
//         private CompanyContext context;
//         public ProjectEmployeeController(CompanyContext context)
//         {
//             this.context = context;
//         }

//         [HttpGet]
//         public async Task<ActionResult<IEnumerable<Employee>>> Get()
//         {
//             //var junctions = context.Set<ProjectEmployeeJunction>();
//             //return new JsonResult(junctions);
//             return await context.Employees.AsNoTracking()
//                 .Include(e => e.Projects).ToListAsync();
//         }
//         [HttpPut]
//         public JsonResult Put(answer answer)
//         {
//             Project project = context.Set<Project>()
//                 .Include(s => s.Employees)
//                 .First(s => s.ProjectId == answer.Id);
//             List<Employee> employees = new List<Employee>(); 
//             foreach(var id in answer.eids)
//             {
//                 try
//                 {
//                     Employee employee = context.Employees
//                         .FirstOrDefault(e=>e.EmployeeId==id);
//                     employees.Add(employee);
//                 } catch
//                 {
//                     Console.WriteLine("Something went wrong");
//                 }                
//             }
//             project.Employees = employees;
            
//             context.SaveChanges();
//             return new JsonResult(project);
//         }
//     }
//     public class answer
//     {
//         public long Id { get; set; }
//         public long[] eids { get; set; }
//     }
// }
