using ApiMinisterioRecomeco.Models;
using ApiMinisterioRecomeco.Repository;

namespace ApiMinisterioRecomeco.Services
{
    public class RelatorioService : IService<Relatorio>
    {
        private readonly IRelatorioRepository _relatorioRepository;

        public RelatorioService(IRelatorioRepository relatorioRepository)
        {
            _relatorioRepository = relatorioRepository;
        }

        public async Task CreateAsync(Relatorio item)
        {
            await _relatorioRepository.CreateAsync(item);
        }

        public async Task DeleteAsync(long id)
        {
            await _relatorioRepository.DeleteAsync(id);
        }

        public async Task<List<Relatorio>> GetAllAsync()
        {
            return await _relatorioRepository.GetAllAsync();
        }

        public async Task<Relatorio> GetByIdAsync(long id)
        {
            return await _relatorioRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(Relatorio item)
        {
            await _relatorioRepository.UpdateAsync(item);
        }
    }
}
