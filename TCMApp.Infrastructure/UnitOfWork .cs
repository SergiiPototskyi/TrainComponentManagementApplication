using TCMApp.Core.Interfaces;

namespace TCMApp.Infrastructure
{
    public class UnitOfWork(ApplicationContext context) : IUnitOfWork
    {
        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await context.SaveChangesAsync(cancellationToken);
        }
    }
}
