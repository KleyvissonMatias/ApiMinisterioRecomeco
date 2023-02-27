using ApiMinisterioRecomeco.Models;
using ApiMinisterioRecomeco.Repository;

namespace ApiMinisterioRecomeco.Infrastructure
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
