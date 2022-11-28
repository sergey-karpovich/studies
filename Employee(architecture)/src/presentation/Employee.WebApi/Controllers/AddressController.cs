using EmployeeAPI.Application.Dtos;
using EmployeeAPI.Repositories.Addresses;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAPI.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressRepository _repository;
        private readonly ILogger<DeveloperController> _logger;
        private readonly IWebHostEnvironment _env;

        public AddressController(
            IWebHostEnvironment env,
            IAddressRepository repository,
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
        public ActionResult GetAddresses()
        {
            _logger.LogInformation("Getting all Addresses");
            var addresses = _repository.GetAllAddresses();

            return Ok(addresses);
        }

        
        [HttpGet("get-addresses-by-id/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult GetAddressById(int id)
        {
            var address = _repository.GetById(id);
            if (address == null)
                return NotFound();
            return Ok(address);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult AddAddress(AddressDTO addressDTO)
        {
            if (addressDTO != null)
            {
                try
                {
                    var address = _repository.Create(addressDTO);
                    return CreatedAtAction("GetAddressById", new { id = address.AddressId }, address);
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
        public ActionResult Put(AddressDTO addressDTO)
        {
            _logger.LogInformation($"Put address {addressDTO}");
            try
            {
                var response = _repository.Update(addressDTO);
                _logger.LogInformation($"Updated  address successfully");
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
            _logger.LogInformation($"Deleting address id={id}");

            var response = _repository.Delete(id);
            return Ok(response);
        }


    }
}
