using ApiMinisterioRecomeco.Models;
using ApiMinisterioRecomeco.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiMinisterioRecomeco.Controllers
{
    [Route("api/v1/[controller]/[action]")]
    [ApiController]
    public class VoluntarioController : ControllerBase
    {
        IService<Voluntario> _service;

        public VoluntarioController(IService<Voluntario> service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var voluntarios = await _service.GetAllAsync();
            return Ok(voluntarios);
        }

        [HttpGet]
        public async Task<IActionResult> GetPorIdAsync([FromQuery] long id)
        {
            var voluntario = await _service.GetByIdAsync(id);
            return Ok(voluntario);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] Voluntario voluntario)
        {
            await _service.CreateAsync(voluntario);
            return Created($"/get-voluntario-por-id?id={voluntario.Id}", voluntario);
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync([FromBody] Voluntario voluntarioAtualizado)
        {
            await _service.UpdateAsync(voluntarioAtualizado);
            return NoContent();
        }

        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
