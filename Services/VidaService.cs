using ApiMinisterioRecomeco.Infrastructure;
using ApiMinisterioRecomeco.Models;

namespace ApiMinisterioRecomeco.Services
{
    public class VidaService : IService<Vida>
    {
        private readonly IVidaRepository _vidaRepository;

        public VidaService(IVidaRepository vidaRepository)
        {
            _vidaRepository = vidaRepository;
        }

        public async Task CreateAsync(Vida item)
        {
            await _vidaRepository.CreateAsync(item);
        }

        public async Task DeleteAsync(long id)
        {
            await _vidaRepository.DeleteAsync(id);
        }

        public async Task<List<Vida>> GetAllAsync()
        {
            return await _vidaRepository.GetAllAsync();
        }

        public async Task<Vida> GetByIdAsync(long id)
        {
            return await _vidaRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(Vida item)
        {
            await _vidaRepository.UpdateAsync(item);
        }
    }
}
