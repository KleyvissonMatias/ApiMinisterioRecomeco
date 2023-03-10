using ApiMinisterioRecomeco.Models;

namespace ApiMinisterioRecomeco.Repository
{
    public abstract class VoluntarioRepository : IRepository<Voluntario>
    {
        public abstract Task<List<Voluntario>> GetAllAsync();
        public abstract Task<Voluntario> GetByIdAsync(Int64 id);
        public abstract Task CreateAsync(Voluntario voluntario);
        public abstract Task UpdateAsync(Voluntario voluntario);
        public abstract Task DeleteAsync(Voluntario voluntario);
    }
}
