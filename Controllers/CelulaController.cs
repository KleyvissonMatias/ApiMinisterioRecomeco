using ApiMinisterioRecomeco.Infrastructure;
using ApiMinisterioRecomeco.Models;
using ApiMinisterioRecomeco.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        [ActionName("Listar")]
        public async Task<IActionResult> GetAllAsync()
        {
            var celulas = await _service.GetAllAsync();
            return Ok(celulas);
        }

        [HttpGet]
        [ActionName("ListarPorId")]
        public async Task<IActionResult> GetPorIdAsync([FromQuery] long id)
        {
            var celulas = await _service.GetByIdAsync(id);
            return Ok(celulas);
        }

        [HttpPost]
        [ActionName("Criar")]
        public async Task<IActionResult> PostAsync([FromBody] Celula celula)
        {
            await _service.CreateAsync(celula);
            return Created($"/get-listar-por-id?id={celula.Id}", celula);
        }

        [HttpPut]
        [ActionName("Atualizar")]
        public async Task<IActionResult> PutAsync([FromBody] Celula celulaAtualizado)
        {
            await _service.UpdateAsync(celulaAtualizado);
            return NoContent();
        }

        [Route("{id}")]
        [HttpDelete]
        [ActionName("Deletar")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
