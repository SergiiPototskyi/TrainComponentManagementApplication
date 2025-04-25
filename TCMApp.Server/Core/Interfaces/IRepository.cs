using TCMApp.Server.Data.Specifications;

namespace TCMApp.Server.Core.Interfaces;

public interface IRepository<T> where T : class, IAggregateRoot
{
    Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken);
    Task<IEnumerable<T>> GetAll(Specification<T> specification, CancellationToken cancellationToken);
    void Add(T entity);
    void Update(T entity);
    void Delete(T entity);
}
