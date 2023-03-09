using ApiMinisterioRecomeco.Exception;
using ApiMinisterioRecomeco.Models;
using ApiMinisterioRecomeco.Repository;
using System.Net;
using static ApiMinisterioRecomeco.Constants.Errors;

namespace ApiMinisterioRecomeco.Services
{
    public class VoluntarioService : IService<Voluntario>
    {
        private readonly VoluntarioRepository _voluntarioRepository;
        private readonly ILogger<Voluntario> _logger;

        public VoluntarioService(VoluntarioRepository voluntarioRepository, ILogger<Voluntario> logger)
        {
            _voluntarioRepository = voluntarioRepository;
            _logger = logger;
        }

        public async Task CreateAsync(Voluntario voluntario)
        {
            try
            {
                await _voluntarioRepository.CreateAsync(voluntario);
            }
            catch (MinisterioRecomecoException ex)
            {
                throw new MinisterioRecomecoException(ex._httpStatusCode, ex._message, ex);
            }
        }

        public async Task DeleteAsync(Int64 id)
        {
            try
            {
                var voluntario = await GetByIdAsync(id) ?? throw new MinisterioRecomecoException(HttpStatusCode.NotFound, ELEMENTO_NAO_ENCONTRADO);
                await _voluntarioRepository.DeleteAsync(voluntario);
            }
            catch (MinisterioRecomecoException ex)
            {
                throw new MinisterioRecomecoException(ex._httpStatusCode, ex._message, ex);
            }
        }

        public async Task<List<Voluntario>> GetAllAsync()
        {
            try
            {
                return await _voluntarioRepository.GetAllAsync();
            }
            catch (MinisterioRecomecoException ex)
            {
                throw new MinisterioRecomecoException(ex._httpStatusCode, ex._message, ex);
            }
        }

        public async Task<Voluntario> GetByIdAsync(Int64 id)
        {
            try
            {
                return await _voluntarioRepository.GetByIdAsync(id) ?? throw new MinisterioRecomecoException(HttpStatusCode.NotFound, ELEMENTO_NAO_ENCONTRADO);
            }
            catch (MinisterioRecomecoException ex)
            {
                throw new MinisterioRecomecoException(ex._httpStatusCode, ex._message, ex);
            }
        }

        public async Task UpdateAsync(Voluntario voluntario)
        {
            try
            {
                voluntario.DataAlteracao = DateTime.Now;

                await _voluntarioRepository.UpdateAsync(voluntario);
            }
            catch (MinisterioRecomecoException ex)
            {
                throw new MinisterioRecomecoException(ex._httpStatusCode, ex._message, ex);
            }
        }
    }
}
