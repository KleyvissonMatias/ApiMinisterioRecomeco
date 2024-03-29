﻿using ApiMinisterioRecomeco.Exception;
using ApiMinisterioRecomeco.Models;
using ApiMinisterioRecomeco.Repository;
using System.Net;
using static ApiMinisterioRecomeco.Constants.Errors;

namespace ApiMinisterioRecomeco.Services
{
    public class RelatorioService : IService<Relatorio>
    {
        private readonly RelatorioRepository _relatorioRepository;
        private readonly ILogger<Relatorio> _logger;

        private const string LOG_SERVICE = "RelatorioService:";

        public RelatorioService(RelatorioRepository relatorioRepository, ILogger<Relatorio> logger)
        {
            _relatorioRepository = relatorioRepository;
            _logger = logger;
        }

        public async Task CreateAsync(Relatorio item)
        {
            try
            {
                _logger.LogInformation(LOG_SERVICE + " [Criando relatório] - [{}]", item);
                await _relatorioRepository.CreateAsync(item);
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
                _logger.LogInformation(LOG_SERVICE + " [Deletando relatório]");
                var relatorio = await GetByIdAsync(id) ?? throw new MinisterioRecomecoException(HttpStatusCode.NotFound, ELEMENTO_NAO_ENCONTRADO);
                await _relatorioRepository.DeleteAsync(relatorio);
            }
            catch (MinisterioRecomecoException ex)
            {
                _logger.LogError(ex, LOG_SERVICE + " [{}]", ex._message);
                throw new MinisterioRecomecoException(ex._httpStatusCode, ex._message, ex);
            }
        }

        public async Task<List<Relatorio>> GetAllAsync()
        {
            try
            {
                _logger.LogInformation(LOG_SERVICE + " [Listando relatórios]");
                return await _relatorioRepository.GetAllAsync();
            }
            catch (MinisterioRecomecoException ex)
            {
                throw new MinisterioRecomecoException(ex._httpStatusCode, ex._message, ex);
            }
        }

        public async Task<Relatorio> GetByIdAsync(Int64 id)
        {
            try
            {
                _logger.LogInformation(LOG_SERVICE + " [Obtendo relatório por ID]");
                return await _relatorioRepository.GetByIdAsync(id) ?? throw new MinisterioRecomecoException(HttpStatusCode.NotFound, ELEMENTO_NAO_ENCONTRADO);
            }
            catch (MinisterioRecomecoException ex)
            {
                _logger.LogError(ex, LOG_SERVICE + " [{}]", ex._message);
                throw new MinisterioRecomecoException(ex._httpStatusCode, ex._message, ex);
            }
        }

        public async Task UpdateAsync(Relatorio item)
        {
            try
            {
                _logger.LogInformation(LOG_SERVICE + " [Atualizando relatório] - [{}]", item);

                item.DataAlteracao = DateTime.Now;

                await _relatorioRepository.UpdateAsync(item);
            }
            catch (MinisterioRecomecoException ex)
            {
                _logger.LogError(ex, LOG_SERVICE + " [{}]", ex._message);
                throw new MinisterioRecomecoException(ex._httpStatusCode, ex._message, ex);
            }
        }
    }
}
