using ApiMinisterioRecomeco.Models;

namespace ApiMinisterioRecomeco.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(Int64 id);
        Task CreateAsync(T t);
        Task UpdateAsync(T t);
        Task DeleteAsync(T t);
    }
}
