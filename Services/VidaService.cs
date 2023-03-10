using ApiMinisterioRecomeco.Exception;
using ApiMinisterioRecomeco.Models;
using ApiMinisterioRecomeco.Repository;
using System.Net;
using static ApiMinisterioRecomeco.Constants.Errors;

namespace ApiMinisterioRecomeco.Services
{
    public class VidaService : IService<Vida>
    {
        private readonly VidaRepository _vidaRepository;
        private readonly ILogger<Vida> _logger;

        private const string LOG_SERVICE = "VidaService:";

        public VidaService(VidaRepository vidaRepository, ILogger<Vida> logger)
        {
            _vidaRepository = vidaRepository;
            _logger = logger;
        }

        public async Task CreateAsync(Vida item)
        {
            try
            {
                _logger.LogInformation(LOG_SERVICE + " [Criando vida]");
                await _vidaRepository.CreateAsync(item);
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
                _logger.LogInformation(LOG_SERVICE + " [Deletando vida]");
                var vida = await GetByIdAsync(id) ?? throw new MinisterioRecomecoException(HttpStatusCode.NotFound, ELEMENTO_NAO_ENCONTRADO);
                await _vidaRepository.DeleteAsync(vida);
            }
            catch (MinisterioRecomecoException ex)
            {
                _logger.LogError(ex, LOG_SERVICE + " [{}]", ex._message);
                throw new MinisterioRecomecoException(ex._httpStatusCode, ex._message, ex);
            }
        }

        public async Task<List<Vida>> GetAllAsync()
        {
            try
            {
                _logger.LogInformation(LOG_SERVICE + " [Listando vidas]");
                return await _vidaRepository.GetAllAsync();
            }
            catch (MinisterioRecomecoException ex)
            {
                _logger.LogError(ex, LOG_SERVICE + " [{}]", ex._message);
                throw new MinisterioRecomecoException(ex._httpStatusCode, ex._message, ex);
            }
        }

        public async Task<Vida> GetByIdAsync(Int64 id)
        {
            try
            {
                _logger.LogInformation(LOG_SERVICE + " [Obtendo vida por ID]");
                return await _vidaRepository.GetByIdAsync(id) ?? throw new MinisterioRecomecoException(HttpStatusCode.NotFound, ELEMENTO_NAO_ENCONTRADO);
            }
            catch (MinisterioRecomecoException ex)
            {
                _logger.LogError(ex, LOG_SERVICE + " [{}]", ex._message);
                throw new MinisterioRecomecoException(ex._httpStatusCode, ex._message, ex);
            }
        }

        public async Task UpdateAsync(Vida item)
        {
            try
            {
                _logger.LogInformation(LOG_SERVICE + " [Atualizando vida]");
                item.DataAlteracao = DateTime.Now;

                await _vidaRepository.UpdateAsync(item);
            }
            catch (MinisterioRecomecoException ex)
            {
                _logger.LogError(ex, LOG_SERVICE + " [{}]", ex._message);
                throw new MinisterioRecomecoException(ex._httpStatusCode, ex._message, ex);
            }
        }
    }
}
