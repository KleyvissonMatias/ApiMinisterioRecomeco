using ApiMinisterioRecomeco.Exception;
using ApiMinisterioRecomeco.Infrastructure;
using ApiMinisterioRecomeco.Models;
using System.Net;

namespace ApiMinisterioRecomeco.Services
{
    public class VoluntarioService : IService<Voluntario>
    {
        private readonly IVoluntarioRepository _voluntarioRepository;
        private readonly ILogger<Voluntario> _logger;

        private const string ERRO_INTERNO = "Ocorreu um erro Interno.";
        private const string ELEMENTO_NAO_ENCONTRADO = "Elemento não encontrado.";

        public VoluntarioService(IVoluntarioRepository voluntarioRepository, ILogger<Voluntario> logger)
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
                throw new MinisterioRecomecoException(HttpStatusCode.InternalServerError, ERRO_INTERNO, ex);
            }
        }

        public async Task DeleteAsync(long id)
        {
            try
            {
                var voluntario = await GetByIdAsync(id) ?? throw new MinisterioRecomecoException(HttpStatusCode.NotFound, ELEMENTO_NAO_ENCONTRADO);
                await _voluntarioRepository.DeleteAsync(voluntario);
            }
            catch (MinisterioRecomecoException ex)
            {
                throw new MinisterioRecomecoException(HttpStatusCode.InternalServerError, ERRO_INTERNO, ex);
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
                throw new MinisterioRecomecoException(HttpStatusCode.InternalServerError, ERRO_INTERNO, ex);
            }
        }

        public async Task<Voluntario> GetByIdAsync(long id)
        {
            try
            {
                return await _voluntarioRepository.GetByIdAsync(id) ?? throw new MinisterioRecomecoException(HttpStatusCode.NotFound, ELEMENTO_NAO_ENCONTRADO);
            }
            catch (MinisterioRecomecoException ex)
            {
                throw new MinisterioRecomecoException(HttpStatusCode.InternalServerError, ERRO_INTERNO, ex);
            }
        }

        public async Task UpdateAsync(Voluntario voluntario)
        {
            try
            {
                await _voluntarioRepository.UpdateAsync(voluntario);
            }
            catch (MinisterioRecomecoException ex)
            {
                throw new MinisterioRecomecoException(HttpStatusCode.InternalServerError, ERRO_INTERNO, ex);
            }
        }
    }
}
