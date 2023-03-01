using ApiMinisterioRecomeco.Models;

namespace ApiMinisterioRecomeco.Services
{
    public interface IService<T>
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(Int64 id);
        Task CreateAsync(T item);
        Task UpdateAsync(T item);
        Task DeleteAsync(Int64 id);
    }
}
