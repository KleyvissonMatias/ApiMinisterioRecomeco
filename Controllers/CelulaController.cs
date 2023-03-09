using ApiMinisterioRecomeco.Exception;
using ApiMinisterioRecomeco.Models;
using ApiMinisterioRecomeco.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ApiMinisterioRecomeco.Controllers
{
    [Route("api/v1/celula/[action]")]
    [ApiController]
    public class CelulaController : ControllerBase
    {
        private readonly CelulaService _service;
        private readonly ILogger<Celula> _logger;
        private const string LOG_CONTROLLER = "CelulaController:";

        public CelulaController(CelulaService service, ILogger<Celula> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        [ActionName("listar")]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                _logger.LogInformation(LOG_CONTROLLER + " [Criando célula]");
                var celulas = await _service.GetAllAsync();
                return Ok(celulas);
            }
            catch (MinisterioRecomecoException ex)
            {
                Response responseError = new()
                {
                    StatusCode = (HttpStatusCode)ex._httpStatusCode,
                    Message = ex._message
                };

                return BadRequest(responseError);
            }
            catch (System.Exception e)
            {
                Response responseError = new()
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Message = e.Message
                };

                _logger.LogError(e, LOG_CONTROLLER + " [{}]", e.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError, responseError);
            }
        }

        [HttpGet]
        [ActionName("listar-por-id")]
        public async Task<IActionResult> GetPorIdAsync([FromQuery] Int64 id)
        {
            try
            {
                _logger.LogInformation(LOG_CONTROLLER + " [Obtendo célula por ID]");
                var celulas = await _service.GetByIdAsync(id);
                return Ok(celulas);
            }
            catch (MinisterioRecomecoException ex)
            {
                Response responseError = new()
                {
                    StatusCode = (HttpStatusCode)ex._httpStatusCode,
                    Message = ex._message
                };

                _logger.LogInformation(LOG_CONTROLLER + " [Criando célula]");
                return BadRequest(responseError);
            }
            catch (System.Exception e)
            {
                Response responseError = new()
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Message = e.Message
                };

                _logger.LogError(e, LOG_CONTROLLER + " [{}]", e.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError, responseError);
            }
        }

        [HttpPost]
        [ActionName("criar")]
        public async Task<IActionResult> PostAsync([FromBody] Celula celula)
        {
            try
            {
                _logger.LogInformation(LOG_CONTROLLER + " [Listando células]");
                await _service.CreateAsync(celula);
                return Created($"/listar-por-id?id={celula.Id}", celula);
            }
            catch (MinisterioRecomecoException ex)
            {
                Response responseError = new()
                {
                    StatusCode = (HttpStatusCode)ex._httpStatusCode,
                    Message = ex._message
                };
                return BadRequest(responseError);
            }
            catch (System.Exception e)
            {
                Response responseError = new()
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Message = e.Message
                };

                _logger.LogError(e, LOG_CONTROLLER + " [{}]", e.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError, responseError);
            }
        }

        [HttpPut]
        [ActionName("atualizar")]
        public async Task<IActionResult> PutAsync([FromBody] Celula celulaAtualizado)
        {
            try
            {
                _logger.LogInformation(LOG_CONTROLLER + " [Atualizando célula]");
                await _service.UpdateAsync(celulaAtualizado);
                return NoContent();
            }
            catch (MinisterioRecomecoException ex)
            {
                Response responseError = new()
                {
                    StatusCode = (HttpStatusCode)ex._httpStatusCode,
                    Message = ex._message
                };
                return BadRequest(responseError);
            }
            catch (System.Exception e)
            {
                Response responseError = new()
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Message = e.Message
                };

                _logger.LogError(e, LOG_CONTROLLER + " [{}]", e.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError, responseError);
            }
        }

        [Route("{id}")]
        [HttpDelete]
        [ActionName("deletar")]
        public async Task<IActionResult> DeleteAsync(Int64 id)
        {
            try
            {
                _logger.LogInformation(LOG_CONTROLLER + " [Deletando célula]");
                await _service.DeleteAsync(id);
                return NoContent();
            }
            catch (MinisterioRecomecoException ex)
            {
                Response responseError = new()
                {
                    StatusCode = (HttpStatusCode)ex._httpStatusCode,
                    Message = ex._message
                };

                return BadRequest(responseError);
            }
            catch (System.Exception e)
            {
                Response responseError = new()
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Message = e.Message
                };

                _logger.LogError(e, LOG_CONTROLLER + " [{}]", e.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError, responseError);
            }
        }
    }
}
