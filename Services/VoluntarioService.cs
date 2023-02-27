using ApiMinisterioRecomeco.Infrastructure;
using ApiMinisterioRecomeco.Models;

namespace ApiMinisterioRecomeco.Services
{
    public class VoluntarioService : IService<Voluntario>
    {
        private readonly IVoluntarioRepository _voluntarioRepository;

        public VoluntarioService(IVoluntarioRepository voluntarioRepository)
        {
            _voluntarioRepository = voluntarioRepository;
        }

        public async Task CreateAsync(Voluntario item)
        {
            await _voluntarioRepository.CreateAsync(item);
        }

        public async Task DeleteAsync(long id)
        {
            await _voluntarioRepository.DeleteAsync(id);
        }

        public async Task<List<Voluntario>> GetAllAsync()
        {
            return await _voluntarioRepository.GetAllAsync();
        }

        public async Task<Voluntario> GetByIdAsync(long id)
        {
            return await _voluntarioRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(Voluntario item)
        {
            await _voluntarioRepository.UpdateAsync(item);
        }
    }
}
