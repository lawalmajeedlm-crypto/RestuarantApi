using RestaurantApi.Models;
using System.Linq.Expressions;

namespace RestaurantApi.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T?> GetByIdAsync(Guid id); 
        Task<IEnumerable<T>> GetAllAsync(); 
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate); 
        Task<T> AddAsync(T entity); 
        Task UpdateAsync(T entity);
        Task SoftDeleteAsync(Guid id); 

        Task<(IEnumerable<T> Data, int TotalRecords)> GetPagedAsync(int pageNumber, int pageSize);
    }
}
