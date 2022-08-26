using Microsoft.AspNetCore.Mvc;
using Packt.Shared;
using NorthwindService.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace NorthwindService.Controllers
{
    // базовый адрес: api/customers  
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private ICustomerRepository repo;
        // конструктор внедряет хранилище, зарегистрированное в Startup 
        public CustomersController(ICustomerRepository repo)
        {
            this.repo = repo;
        }
        // GET: api/customers   
        // GET: api/customers/?country=[country]   
        // всегда будет возвращать список клиентов, даже если он пуст 
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Customer>))]
        public async Task<IEnumerable<Customer>> GetCustomers(
                 string country)
        {
            if (string.IsNullOrWhiteSpace(country))
            {
                return await repo.RetrieveAllAsync();
            }
            else 
            { 
                return (await repo.RetrieveAllAsync())
                .Where(customer => customer.Country == country); 
            }
        }
        // GET: api/customers/[id]    
        [HttpGet("{id}", Name = nameof(GetCustomer))]
        // именованный маршрут   
        [ProducesResponseType(200, Type = typeof(Customer))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetCustomer(string id)
        {
            Customer c = await repo.RetrieveAsync(id);
            if (c == null)
            {
                return NotFound();
                // 404 Ресурс не обнаружен  
            }
            return Ok(c);
            // 200 Возвращает ОК с клиентом в теле ответа  
        }
        // POST: api/customers    
        // BODY: Customer (JSON, XML)  
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(Customer))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Create([FromBody] Customer c)
        {
            if (c == null)
            {
                return BadRequest();
                // 400 Неверный запрос    
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
                // 400 Неверный запрос   
            }
            Customer added = await repo.CreateAsync(c);
            return CreatedAtRoute(
               // 201 Создано     
               routeName: nameof(GetCustomer),
                  routeValues: new { id = added.CustomerID.ToLower() },
                      value: added);
        }
        // PUT: api/customers/[id]  
        // BODY: Customer (JSON, XML)  
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Update(
            string id, [FromBody] Customer c)
        {
            id = id.ToUpper();
            c.CustomerID = c.CustomerID.ToUpper();
            if (c == null || c.CustomerID != id)
            {
                return BadRequest();
                // 400 Неверный запрос    
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
                // 400 Неверный запрос   
            }
            var existing = await repo.RetrieveAsync(id);
            if (existing == null)
            {
                return NotFound();
                // 404 Ресурс не обнаружен     
            }
            await repo.UpdateAsync(id, c);
            return new NoContentResult();
            // 204 Нет контента  
        }
        // DELETE: api/customers/[id] 
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Delete(string id)
        {
            //контроль проблемы
            if(id=="bad")
            {
                var problemDetails=new ProblemDetails
                {
                    Status=StatusCodes.Status400BadRequest,
                    Type="https://localhost:5001/customers/failed-to-delete",
                    Title=$"Customer ID {id} found but failed to delete.",
                    Detail="More details like Company Name, COuntry and so on.",
                    Instance=HttpContext.Request.Path
                };
                return BadRequest(problemDetails);
            }
            var existing = await repo.RetrieveAsync(id);
            if (existing == null)
            {
                return NotFound();
                // 404 Ресурс не обнаружен     
            }
            bool? deleted = await repo.DeleteAsync(id);
            if (deleted.HasValue && deleted.Value)
            // короткозамкнутая AND     
            {
                return new NoContentResult();
                // 204 Нет контента    
            }
            else
            {
                return BadRequest( // 400 Неверный запрос  
                    $"Customer {id} was found but failed to delete.");
            }
        }
    }
}