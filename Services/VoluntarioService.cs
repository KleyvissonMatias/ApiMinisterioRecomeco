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

        private const string LOG_SERVICE = "VoluntarioService:";

        public VoluntarioService(VoluntarioRepository voluntarioRepository, ILogger<Voluntario> logger)
        {
            _voluntarioRepository = voluntarioRepository;
            _logger = logger;
        }

        public async Task CreateAsync(Voluntario voluntario)
        {
            try
            {
                _logger.LogInformation(LOG_SERVICE + " [Criando voluntário] - [{}]", voluntario);
                await _voluntarioRepository.CreateAsync(voluntario);
            }
            catch (MinisterioRecomecoException ex)
            {
                _logger.LogError(ex, LOG_SERVICE + " [{}]", ex._message);
                throw new MinisterioRecomecoException(ex._httpStatusCode, ex._message, ex);
            }
        }

        public async Task DeleteAsync(Int64 id)
        {
            try
            {
                _logger.LogInformation(LOG_SERVICE + " [Deletando voluntário]");
                var voluntario = await GetByIdAsync(id) ?? throw new MinisterioRecomecoException(HttpStatusCode.NotFound, ELEMENTO_NAO_ENCONTRADO);
                await _voluntarioRepository.DeleteAsync(voluntario);
            }
            catch (MinisterioRecomecoException ex)
            {
                _logger.LogError(ex, LOG_SERVICE + " [{}]", ex._message);
                throw new MinisterioRecomecoException(ex._httpStatusCode, ex._message, ex);
            }
        }

        public async Task<List<Voluntario>> GetAllAsync()
        {
            try
            {
                _logger.LogInformation(LOG_SERVICE + " [Listando voluntários]");
                return await _voluntarioRepository.GetAllAsync();
            }
            catch (MinisterioRecomecoException ex)
            {
                _logger.LogError(ex, LOG_SERVICE + " [{}]", ex._message);
                throw new MinisterioRecomecoException(ex._httpStatusCode, ex._message, ex);
            }
        }

        public async Task<Voluntario> GetByIdAsync(Int64 id)
        {
            try
            {
                _logger.LogInformation(LOG_SERVICE + " [Obtendo voluntário por ID]");
                return await _voluntarioRepository.GetByIdAsync(id) ?? throw new MinisterioRecomecoException(HttpStatusCode.NotFound, ELEMENTO_NAO_ENCONTRADO);
            }
            catch (MinisterioRecomecoException ex)
            {
                _logger.LogError(ex, LOG_SERVICE + " [{}]", ex._message);
                throw new MinisterioRecomecoException(ex._httpStatusCode, ex._message, ex);
            }
        }

        public async Task UpdateAsync(Voluntario voluntario)
        {
            try
            {
                _logger.LogInformation(LOG_SERVICE + " [Atualizando voluntário] - [{}]", voluntario);

                voluntario.DataAlteracao = DateTime.Now;

                await _voluntarioRepository.UpdateAsync(voluntario);
            }
            catch (MinisterioRecomecoException ex)
            {
                _logger.LogError(ex, LOG_SERVICE + " [{}]", ex._message);
                throw new MinisterioRecomecoException(ex._httpStatusCode, ex._message, ex);
            }
        }
    }
}
