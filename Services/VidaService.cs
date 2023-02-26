using ApiMinisterioRecomeco.Infrastructure;
using ApiMinisterioRecomeco.Models;

namespace ApiMinisterioRecomeco.Services
{
    public class VidaService : IService<Vida>
    {
        IVidaRepository _vidaRepository;

        public VidaService(IVidaRepository vidaRepository)
        {
            _vidaRepository = vidaRepository;
        }

        public async Task Create(Vida item)
        {
            await _vidaRepository.Create(item);
        }

        public async Task Delete(long id)
        {
            await _vidaRepository.Delete(id);
        }

        public async Task<List<Vida>> GetAll()
        {
            return await _vidaRepository.GetAll();
        }

        public async Task<Vida> GetById(long id)
        {
            return await _vidaRepository.GetById(id);
        }

        public async Task Update(Vida item)
        {
            await _vidaRepository.Update(item);
        }
    }
}
