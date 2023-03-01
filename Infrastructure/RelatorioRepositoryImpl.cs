﻿using ApiMinisterioRecomeco.Configuration;
using ApiMinisterioRecomeco.Models;
using ApiMinisterioRecomeco.Repository;
using Microsoft.EntityFrameworkCore;

namespace ApiMinisterioRecomeco.Infrastructure
{
    public class RelatorioRepositoryImpl : IRelatorioRepository
    {
        private readonly AppDbContext _dbContext;

        public RelatorioRepositoryImpl(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateAsync(Relatorio relatorio)
        {
            _dbContext.Relatorios.Add(relatorio);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Relatorio relatorio)
        {
            _dbContext.Relatorios.Remove(relatorio);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Relatorio>> GetAllAsync()
        {
            return await _dbContext.Relatorios.ToListAsync();
        }

        public async Task<Relatorio> GetByIdAsync(Int64 id)
        {
            return await _dbContext.Relatorios.FindAsync(id);
        }

        public async Task UpdateAsync(Relatorio relatorio)
        {
            _dbContext.Relatorios.Update(relatorio);
            await _dbContext.SaveChangesAsync();
        }
    }
}
