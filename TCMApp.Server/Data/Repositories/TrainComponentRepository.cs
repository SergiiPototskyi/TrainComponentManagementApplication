using Microsoft.EntityFrameworkCore;
using TCMApp.Server.Core.Entities;
using TCMApp.Server.Data.Specifications;

namespace TCMApp.Server.Data.Repositories;

public class TrainComponentRepository(ApplicationContext context) : BaseRepository<TrainComponent>(context)
{
    public override async Task<IEnumerable<TrainComponent>> GetAll(
        Specification<TrainComponent> specification, 
        CancellationToken cancellationToken)
    {
        return await GetIncludableQueryable()
            .Where(specification.ToExpression())
            .OrderBy(x => x.Id)
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    protected override IQueryable<TrainComponent> GetIncludableQueryable()
    {
        return _context.Set<TrainComponent>();
    }
}
