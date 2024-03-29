﻿using ApiMinisterioRecomeco.Configuration;
using ApiMinisterioRecomeco.Models;
using ApiMinisterioRecomeco.Repository;
using Microsoft.EntityFrameworkCore;

namespace ApiMinisterioRecomeco.Infrastructure
{
    public class CelulaRepositoryImpl : CelulaRepository
    {
        private readonly AppDbContext _dbContext;

        public CelulaRepositoryImpl(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task CreateAsync(Celula celula)
        {
            _dbContext.Celulas.Add(celula);
            await _dbContext.SaveChangesAsync();
        }

        public override async Task DeleteAsync(Celula celula)
        {
            _dbContext.Celulas.Remove(celula);
            await _dbContext.SaveChangesAsync();
        }

        public override async Task<List<Celula>> GetAllAsync()
        {
            return await _dbContext.Celulas.Include(e => e.Endereco).ToListAsync();
        }

        public override async Task<Celula> GetByIdAsync(Int64 id)
        {
            return await _dbContext.Celulas.Include(e => e.Endereco).FirstOrDefaultAsync(c => c.Id == id) ?? await Task.FromResult<Celula>(null);
        }

        public override async Task UpdateAsync(Celula celula)
        {
            _dbContext.Celulas.Update(celula);
            await _dbContext.SaveChangesAsync();
        }
    }
}
