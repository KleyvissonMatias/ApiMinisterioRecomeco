using ApiMinisterioRecomeco.Exception;
using static ApiMinisterioRecomeco.Constants.Errors;
using ApiMinisterioRecomeco.Models;
using ApiMinisterioRecomeco.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Microsoft.AspNetCore.Http.HttpResults;

namespace ApiMinisterioRecomeco.Controllers
{
    [Route("api/v1/[controller]/[action]")]
    [ApiController]
    public class CelulaController : ControllerBase
    {
        private readonly IService<Celula> _service;

        public CelulaController(IService<Celula> service)
        {
            _service = service;
        }

        [HttpGet]
        [ActionName("listar")]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
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
                return StatusCode((int)HttpStatusCode.InternalServerError, responseError);
            }
        }

        [HttpGet]
        [ActionName("listar-por-id")]
        public async Task<IActionResult> GetPorIdAsync([FromQuery] Int64 id)
        {
            try
            {
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
        public async Task<IActionResult> PostAsync([FromBody] Celula celula)
        {
            try
            {
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
                return StatusCode((int)HttpStatusCode.InternalServerError, responseError);
            }
        }

        [HttpPut]
        [ActionName("atualizar")]
        public async Task<IActionResult> PutAsync([FromBody] Celula celulaAtualizado)
        {
            try
            {
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
