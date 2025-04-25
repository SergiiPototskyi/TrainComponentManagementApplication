using TCMApp.Server.Core.Interfaces;

namespace TCMApp.Server.Data;

public class UnitOfWork(ApplicationContext context) : IUnitOfWork
{
    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
    {
        return await context.SaveChangesAsync(cancellationToken);
    }
}
