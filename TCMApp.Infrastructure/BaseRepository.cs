using Microsoft.EntityFrameworkCore;
using TCMApp.Core.Interfaces;
using TCMApp.Core.Specifications;

namespace TCMApp.Infrastructure
{
    public abstract class BaseRepository<T> : IRepository<T> where T : class, IAggregateRoot
    {
        protected readonly ApplicationContext _context;

        public BaseRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await GetIncludableQueryable()
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public abstract Task<IEnumerable<T>> GetAll(Specification<T> specification, CancellationToken cancellationToken);

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }

        public virtual void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        protected abstract IQueryable<T> GetIncludableQueryable();
    }
}