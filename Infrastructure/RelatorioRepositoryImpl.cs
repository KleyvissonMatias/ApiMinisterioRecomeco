using ApiMinisterioRecomeco.Configuration;
using ApiMinisterioRecomeco.Models;
using ApiMinisterioRecomeco.Repository;

namespace ApiMinisterioRecomeco.Infrastructure
{
    public class RelatorioRepositoryImpl : IRelatorioRepository
    {
        private readonly MinisterioDbContext _dbContext;
        private readonly ILogger<Relatorio> _logger;

        private const string ERRO_INTERNO = "Ocorreu um erro Interno.";
        private const string ELEMENTO_NAO_ENCONTRADO = "Elemento não encontrado.";

        public RelatorioRepositoryImpl(MinisterioDbContext dbContext, ILogger<Relatorio> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public Task Create(Relatorio item)
        {
            throw new NotImplementedException();
        }

        public Task Delete(long id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Relatorio>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Relatorio> GetById(long id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Relatorio item)
        {
            throw new NotImplementedException();
        }
    }
}
