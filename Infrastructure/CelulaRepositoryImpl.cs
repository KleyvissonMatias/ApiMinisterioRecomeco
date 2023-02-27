using ApiMinisterioRecomeco.Configuration;
using ApiMinisterioRecomeco.Exception;
using ApiMinisterioRecomeco.Models;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace ApiMinisterioRecomeco.Infrastructure
{
    public class CelulaRepositoryImpl : ICelulaRepository
    {
        private readonly AppDbContext _dbContext;

        public CelulaRepositoryImpl(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateAsync(Celula item)
        {
            _dbContext.Celulas.Add(item);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Celula item)
        {
            _dbContext.Celulas.Remove(item);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Celula>> GetAllAsync()    
        {
            return await _dbContext.Celulas.ToListAsync();
        }

        public async Task<Celula> GetByIdAsync(long id)
        {
            return await _dbContext.Celulas.FindAsync(id);
        }

        public async Task UpdateAsync(Celula item)
        {
            _dbContext.Celulas.Update(item);
            await _dbContext.SaveChangesAsync();
        }
    }
}
