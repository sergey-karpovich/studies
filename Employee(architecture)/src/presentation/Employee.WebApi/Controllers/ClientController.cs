using EmployeeAPI.Application.Dtos;
using EmployeeAPI.Repositories.Clients;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAPI.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientRepository _repository;
        public ClientController(IClientRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var clients = _repository.GetAll();
            return Ok(clients);
        }

        [HttpGet("{id}")]
        public ActionResult GetClientById(int id)
        {
            var client = _repository.GetById(id);
            if (client == null)
                return NotFound();
            return Ok(client);
        }

        [HttpPost]
        public ActionResult AddClient(ClientDTO clientDTO)
        {
            if(ModelState.IsValid)
            {
                var client = _repository.Create(clientDTO);
                return CreatedAtAction(nameof(GetClientById), 
                    new { id = client.ClientId },client);
            }
            return BadRequest();
        }

        [HttpPut]
        public ActionResult Put (ClientDTO clientDTO)
        {
            var response = _repository.Update(clientDTO);
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
