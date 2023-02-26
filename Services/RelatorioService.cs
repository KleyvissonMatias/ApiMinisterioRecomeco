using ApiMinisterioRecomeco.Models;
using ApiMinisterioRecomeco.Repository;

namespace ApiMinisterioRecomeco.Services
{
    public class RelatorioService : IService<Relatorio>
    {
        IRelatorioRepository _relatorioRepository;

        public RelatorioService(IRelatorioRepository relatorioRepository)
        {
            _relatorioRepository = relatorioRepository;
        }

        public async Task Create(Relatorio item)
        {
            await _relatorioRepository.Create(item);
        }

        public async Task Delete(long id)
        {
            await _relatorioRepository.Delete(id);
        }

        public async Task<List<Relatorio>> GetAll()
        {
            return await _relatorioRepository.GetAll();
        }

        public async Task<Relatorio> GetById(long id)
        {
            return await _relatorioRepository.GetById(id);
        }

        public async Task Update(Relatorio item)
        {
            await _relatorioRepository.Update(item);
        }
    }
}
