using ApiMinisterioRecomeco.Infrastructure;
using ApiMinisterioRecomeco.Models;

namespace ApiMinisterioRecomeco.Services
{
    public class CelulaService : IService<Celula>
    {
        ICelulaRepository _celulaRepository;

        public CelulaService(ICelulaRepository celulaRepository)
        {
            _celulaRepository = celulaRepository;
        }

        public async Task Create(Celula item)
        {
            await _celulaRepository.Create(item);
        }

        public async Task Delete(long id)
        {
            await _celulaRepository.Delete(id);
        }

        public async Task<List<Celula>> GetAll()
        {
            return await _celulaRepository.GetAll();
        }

        public async Task<Celula> GetById(long id)
        {
            return await _celulaRepository.GetById(id);
        }

        public async Task Update(Celula item)
        {
            await _celulaRepository.Update(item);
        }
    }
}
