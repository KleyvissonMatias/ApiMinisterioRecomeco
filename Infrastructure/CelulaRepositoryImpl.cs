using ApiMinisterioRecomeco.Configuration;
using ApiMinisterioRecomeco.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiMinisterioRecomeco.Infrastructure
{
    public class CelulaRepositoryImpl : ICelulaRepository
    {
        private readonly AppDbContext _dbContext;

        public CelulaRepositoryImpl(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateAsync(Celula celula)
        {
            _dbContext.Celulas.Add(celula);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Celula celula)
        {
            _dbContext.Celulas.Remove(celula);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Celula>> GetAllAsync()
        {
            return await _dbContext.Celulas.Include(e => e.Endereco).ToListAsync();
        }

        public async Task<Celula> GetByIdAsync(Int64 id)
        {
            return await _dbContext.Celulas.Include(e => e.Endereco).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task UpdateAsync(Celula celula)
        {
            _dbContext.Celulas.Update(celula);
            await _dbContext.SaveChangesAsync();
        }
    }
}
