using ApiMinisterioRecomeco.Configuration;
using ApiMinisterioRecomeco.Exception;
using ApiMinisterioRecomeco.Models;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace ApiMinisterioRecomeco.Infrastructure
{
    public class CelulaRepositoryImpl : ICelulaRepository
    {
        private readonly MinisterioDbContext _dbContext;
        private readonly ILogger<Celula> _logger;

        private const string ERRO_INTERNO = "Ocorreu um erro Interno.";
        private const string ELEMENTO_NAO_ENCONTRADO = "Elemento não encontrado.";

        public CelulaRepositoryImpl(MinisterioDbContext dbContext, ILogger<Celula> logger)
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
                    throw new MinisterioRecomecoException(HttpStatusCode.NotFound, ELEMENTO_NAO_ENCONTRADO);
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
            try
            {
                return await _dbContext.Celulas.ToListAsync();
            }
            catch (MinisterioRecomecoException ex)
            {
                throw new MinisterioRecomecoException(HttpStatusCode.InternalServerError, ERRO_INTERNO, ex);
            }
        }

        public async Task<Celula> GetById(long id)
        {
            try
            {
                var celula = await _dbContext.Celulas.FindAsync(id);

                if (celula == null)
                {
                    throw new MinisterioRecomecoException(HttpStatusCode.NotFound, ELEMENTO_NAO_ENCONTRADO);
                }

                return celula;

            }
            catch (MinisterioRecomecoException ex)
            {
                throw new MinisterioRecomecoException(HttpStatusCode.InternalServerError, ERRO_INTERNO, ex);
            }
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
