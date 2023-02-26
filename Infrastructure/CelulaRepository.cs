using ApiMinisterioRecomeco.Exception;
using ApiMinisterioRecomeco.Models;
using ApiMinisterioRecomeco.Repository;
using System.Net;

namespace ApiMinisterioRecomeco.Infrastructure
{
    public class CelulaRepository : ICelulaRepository
    {
        private readonly MinisterioDbContext _dbContext;
        private readonly ILogger<Celula> _logger;
        private const string ERRO_INTERNO = "Erro Interno";

        public CelulaRepository(MinisterioDbContext dbContext, ILogger<Celula> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task Create(Celula item)
        {
            try
            {
                _dbContext.Celulas.Add(item);
                await _dbContext.SaveChangesAsync();

            }
            catch (MinisterioRecomecoException ex)
            {
                throw new MinisterioRecomecoException(HttpStatusCode.InternalServerError, ERRO_INTERNO, ex);
            }
        }

        public async Task Delete(long id)
        {
            try
            {
                var celula = await _dbContext.Celulas.FindAsync(id);
                if (celula == null)
                {
                    throw new MinisterioRecomecoException(HttpStatusCode.NotFound, "Elemento não encontrado.");
                }

                _dbContext.Celulas.Remove(celula);
                await _dbContext.SaveChangesAsync();
            }
            catch (MinisterioRecomecoException ex)
            {
                throw new MinisterioRecomecoException(HttpStatusCode.InternalServerError, ERRO_INTERNO, ex);
            }
        }

        public async Task<List<Celula>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<Celula> GetById(long id)
        {
            throw new NotImplementedException();
        }

        public async Task Update(Celula item)
        {
            try
            {
                _dbContext.Celulas.Update(item);
                await _dbContext.SaveChangesAsync();
            }
            catch (MinisterioRecomecoException ex)
            {
                throw new MinisterioRecomecoException(HttpStatusCode.InternalServerError, ERRO_INTERNO, ex);
            }
        }
    }
}
