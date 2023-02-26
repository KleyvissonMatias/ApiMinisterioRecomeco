using ApiMinisterioRecomeco.Models;
using ApiMinisterioRecomeco.Repository;

namespace ApiMinisterioRecomeco.Infrastructure
{
    public class CelulaRepository : ICelulaRepository
    {
        private readonly DbContext _dbContext;

        public CelulaRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Create(Celula item)
        {
            try
            {
                _dbContext.Celulas.Add(item);
                await _dbContext.SaveChangesAsync();

            }catch (Exception ex)
            {
                throw new Exception("", ex);
            }
        }

        public async Task Delete(long id)
        {
            var celula = await _dbContext.Celulas.FindAsync(id);
            if (celula == null)
            {

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

        public async Task<Celula> Update(Celula item)
        {
            throw new NotImplementedException();
        }
    }
}
