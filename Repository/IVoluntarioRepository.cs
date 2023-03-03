using ApiMinisterioRecomeco.Models;

namespace ApiMinisterioRecomeco.Infrastructure
{
    public interface IVoluntarioRepository
    {
        Task<List<Voluntario>> GetAllAsync();
        Task<Voluntario> GetByIdAsync(Int64 id);
        Task CreateAsync(Voluntario voluntario);
        Task UpdateAsync(Voluntario voluntario);
        Task DeleteAsync(Voluntario voluntario);
    }
}
