using EmployeeAPI.Application.Dtos;
using EmployeeAPI.Services.TarifService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAPI.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarifController : ControllerBase
    {
        private readonly ITarifRepository _repository;
        private readonly ILogger<TarifController> _logger;
        
        public TarifController(ITarifRepository repository, ILogger<TarifController> logger)
        {
            _repository = repository;
            _logger = logger;
            
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult GetTarifs()
        {
            _logger.LogInformation("Getting all Tarifs from controller");
            var addresses = _repository.GetAll();

            return Ok(addresses);
        }


        [HttpGet("get-tarif-by-id/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult GetTarifById(int id)
        {
            var tarif = _repository.GetById(id);
            if (tarif == null)
                return NotFound();
            return Ok(tarif);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult AddTarif(TarifDTO tarifDTO)
        {
            if (tarifDTO != null)
            {
                try
                {
                    var tarif = _repository.Create(tarifDTO);
                    return CreatedAtAction("GetTarifById", new { id = tarif.TarifId }, tarif);
                }
                catch (Exception e)
                {
                    _logger.LogError($"TarifController Error {e.Message} \n {e.StackTrace}");
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
        public ActionResult Put(TarifDTO tarifDTO)
        {
            _logger.LogInformation($"Put tarif {tarifDTO}");
            try
            {
                var response = _repository.Update(tarifDTO);
                _logger.LogInformation($"Updated  tarif successfully");
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
            _logger.LogInformation($"Deleting tarif id={id}");

            var response = _repository.Delete(id);
            return Ok(response);
        }
    }
}
