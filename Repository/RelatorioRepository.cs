using ApiMinisterioRecomeco.Models;

namespace ApiMinisterioRecomeco.Repository
{
    public abstract class RelatorioRepository : IRepository<Relatorio>
    {
        public abstract Task<List<Relatorio>> GetAllAsync();
        public abstract Task<Relatorio> GetByIdAsync(Int64 id);
        public abstract Task CreateAsync(Relatorio relatorio);
        public abstract Task UpdateAsync(Relatorio relatorio);
        public abstract Task DeleteAsync(Relatorio relatorio);
    }
}
