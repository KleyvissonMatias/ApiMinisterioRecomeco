using ApiMinisterioRecomeco.Models;

namespace ApiMinisterioRecomeco.Services
{
    public interface IService<T>
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(long id);
        Task CreateAsync(T item);
        Task UpdateAsync(T item);
        Task DeleteAsync(long id);
    }
}
