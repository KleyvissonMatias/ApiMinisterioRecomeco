using ApiMinisterioRecomeco.Exception;
using ApiMinisterioRecomeco.Models;
using ApiMinisterioRecomeco.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ApiMinisterioRecomeco.Controllers
{
    [Route("api/v1/voluntario/[action]")]
    [ApiController]
    public class VoluntarioController : ControllerBase
    {
        private readonly VoluntarioService _service;

        public VoluntarioController(VoluntarioService service)
        {
            _service = service;
        }

        [HttpGet]
        [ActionName("listar")]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var voluntarios = await _service.GetAllAsync();
                return Ok(voluntarios);
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
                return StatusCode((int)HttpStatusCode.InternalServerError, responseError);
            }
        }

        [HttpGet]
        [ActionName("listar-por-id")]
        public async Task<IActionResult> GetPorIdAsync([FromQuery] Int64 id)
        {
            try
            {
                var voluntario = await _service.GetByIdAsync(id);
                return Ok(voluntario);
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
                return StatusCode((int)HttpStatusCode.InternalServerError, responseError);
            }
        }

        [HttpPost]
        [ActionName("criar")]
        public async Task<IActionResult> PostAsync([FromBody] Voluntario voluntario)
        {
            try
            {
                await _service.CreateAsync(voluntario);
                return Created($"/listar-por-id?id={voluntario.Id}", voluntario);
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
                return StatusCode((int)HttpStatusCode.InternalServerError, responseError);
            }
        }

        [HttpPut]
        [ActionName("atualizar")]
        public async Task<IActionResult> PutAsync([FromBody] Voluntario voluntarioAtualizado)
        {
            try
            {
                await _service.UpdateAsync(voluntarioAtualizado);
                return NoContent(); ;
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
                return StatusCode((int)HttpStatusCode.InternalServerError, responseError);
            }
        }
    }
}
