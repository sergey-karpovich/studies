// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Employee.Data.Contexts;
// using Employee.Domain.Entities;
// using Microsoft.AspNetCore.Http;
// using Microsoft.AspNetCore.Mvc;


// namespace Employee.WebApi.Controllers
// {
//     [Route("api/[controller]")]
//     [ApiController]
//     public class WorkTimesController : ControllerBase
//     {
//         private readonly CompanyContext _context;

//         public WorkTimesController(CompanyContext context)
//         {
//             _context = context;
//         }

//         // GET: api/WorkTimes
//         [HttpGet]
//         public async Task<ActionResult<IEnumerable<WorkTime>>> GetWorkTimes()
//         {
//             return await _context.WorkTimes.ToListAsync();
//         }

//         // GET: api/WorkTimes/5
//         [HttpGet("{year}")]
//         public async Task<ActionResult<IEnumerable<WorkTime>>> GetWorkTime(long year)
//         {

//             var workTime = await _context.WorkTimes
//                 .Where(wt => wt.NumYear == year)
//                 .ToListAsync();

//             if (workTime == null)
//             {
//                 return NotFound();
//             }

//             return workTime;
//         }

//         // PUT: api/WorkTimes/5
//         // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
//         [HttpPut("{id}")]
//         public async Task<IActionResult> PutWorkTime(long id, WorkTime workTime)
//         {
//             if (id != workTime.Id)
//             {
//                 return BadRequest();
//             }

//             _context.Entry(workTime).State = EntityState.Modified;

//             try
//             {
//                 await _context.SaveChangesAsync();
//             }
//             catch (DbUpdateConcurrencyException)
//             {
//                 if (!WorkTimeExists(id))
//                 {
//                     return NotFound();
//                 }
//                 else
//                 {
//                     throw;
//                 }
//             }
//             return new JsonResult("Updated Successfully");
//         }

//         // POST: api/WorkTimes
//         // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
//         [HttpPost]
//         public async Task<ActionResult<WorkTime>> PostWorkTime(WorkTime workTime)
//         {
//             _context.WorkTimes.Add(workTime);
//             await _context.SaveChangesAsync();

//             return CreatedAtAction(nameof(GetWorkTime), new { id = workTime.Id }, workTime);
//         }

//         // DELETE: api/WorkTimes/5
//         [HttpDelete("{id}")]
//         public async Task<IActionResult> DeleteWorkTime(long id)
//         {
//             var workTime = await _context.WorkTimes.FindAsync(id);
//             if (workTime == null)
//             {
//                 return NotFound();
//             }

//             _context.WorkTimes.Remove(workTime);
//             await _context.SaveChangesAsync();

//             return new JsonResult("Deleted Successfully");
//         }

//         private bool WorkTimeExists(long id)
//         {
//             return _context.WorkTimes.Any(e => e.Id == id);
//         }
//     }
// }
