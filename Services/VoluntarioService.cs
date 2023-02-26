using ApiMinisterioRecomeco.Infrastructure;
using ApiMinisterioRecomeco.Models;

namespace ApiMinisterioRecomeco.Services
{
    public class VoluntarioService : IService<Voluntario>
    {
        IVoluntarioRepository _voluntarioRepository;

        public VoluntarioService(IVoluntarioRepository voluntarioRepository)
        {
            _voluntarioRepository = voluntarioRepository;
        }

        public async Task Create(Voluntario item)
        {
            await _voluntarioRepository.Create(item);
        }

        public async Task Delete(long id)
        {
            await _voluntarioRepository.Delete(id);
        }

        public async Task<List<Voluntario>> GetAll()
        {
            return await _voluntarioRepository.GetAll();
        }

        public async Task<Voluntario> GetById(long id)
        {
            return await _voluntarioRepository.GetById(id);
        }

        public async Task Update(Voluntario item)
        {
            await _voluntarioRepository.Update(item);
        }
    }
}
