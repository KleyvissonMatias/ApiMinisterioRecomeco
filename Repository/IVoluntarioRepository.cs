using ApiMinisterioRecomeco.Models;

namespace ApiMinisterioRecomeco.Repository
{
    public interface IVoluntarioRepository
    {
        Task<List<Voluntario>> GetAllAsync();
        Task<Voluntario> GetByIdAsync(long id);
        Task CreateAsync(Voluntario voluntario);
        Task UpdateAsync(Voluntario voluntario);
        Task DeleteAsync(Voluntario voluntario);
    }
}
