using Rms.Models.Common;
using System.Linq.Expressions;


namespace Rms.BLL.Abstraction.Base
{
    public interface IManager<T> : IDisposable where T:class
    {
        Task<Result> Add(T entity);
        Task<bool> AddAsync(T entity);
        Task<Result> Update(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<Result> Remove(long id);
        Task<Result> Remove(int id);
        Task<ICollection<T>> GetAll();
        Task<T> GetById(long id);
        Task<T> GetById(int id);
        Task<T> GetFirstorDefault(Expression<Func<T, bool>> predicate);
        Task<bool> RemoveAsync(T entity);
        Task<Result> AddRangeAsync(ICollection<T> entities);
        Task<Result> UpdateRangeAsync(ICollection<T> entity);
    }
}
