using System.Linq.Expressions;

namespace Clinic.Repositories.IRepos
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProperties = null);
        Task<T?> GetFirstOrDefault(Expression<Func<T, bool>> query, string? includeProperties = null);
        Task Add(T item);
        Task Remove(T item);

    }
}
