using ApiMinisterioRecomeco.Configuration;
using ApiMinisterioRecomeco.Models;
using ApiMinisterioRecomeco.Repository;

namespace ApiMinisterioRecomeco.Infrastructure
{
    public class RelatorioRepositoryImpl : IRelatorioRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly ILogger<Relatorio> _logger;

        private const string ERRO_INTERNO = "Ocorreu um erro Interno.";
        private const string ELEMENTO_NAO_ENCONTRADO = "Elemento não encontrado.";

        public RelatorioRepositoryImpl(AppDbContext dbContext, ILogger<Relatorio> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public Task CreateAsync(Relatorio item)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Relatorio>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Relatorio> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Relatorio item)
        {
            throw new NotImplementedException();
        }
    }
}
