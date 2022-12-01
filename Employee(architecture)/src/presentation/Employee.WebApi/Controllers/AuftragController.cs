using EmployeeAPI.Application.Dtos;
using EmployeeAPI.Repositories.Auftrags;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAPI.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuftragController : ControllerBase
    {
        private readonly IAuftragRepository _repository;
        public AuftragController(IAuftragRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var auftrags = _repository.GetAll();
            return Ok(auftrags);
        }

        [HttpGet("{id}")]
        public ActionResult GetAuftragById(int id)
        {
            var auftrag = _repository.GetById(id);
            if (auftrag == null)
                return NotFound();
            return Ok(auftrag);
        }

        [HttpPost]
        public ActionResult Add(AuftragDTO auftragDTO)
        {
            if (ModelState.IsValid)
            {
                var auftrag = _repository.Create(auftragDTO);
                return CreatedAtAction(nameof(GetAuftragById),
                    new { id = auftrag.AuftragId }, auftrag);
            }
            return BadRequest();
        }

        [HttpPut]
        public ActionResult Put(AuftragDTO auftragDTO)
        {
            var response = _repository.Update(auftragDTO);
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
