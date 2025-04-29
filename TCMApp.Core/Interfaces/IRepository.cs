using TCMApp.Core.Specifications;

namespace TCMApp.Core.Interfaces
{
    public interface IRepository<T> where T : class, IAggregateRoot
    {
        Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task<IEnumerable<T>> GetAll(Specification<T> specification, CancellationToken cancellationToken);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
