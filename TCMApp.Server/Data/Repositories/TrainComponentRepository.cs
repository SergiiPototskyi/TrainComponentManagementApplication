using Microsoft.EntityFrameworkCore;
using TCMApp.Server.Core.Entities;
using TCMApp.Server.Core.Interfaces;
using TCMApp.Server.Data.Specifications;

namespace TCMApp.Server.Data.Repositories
{
    public class TrainComponentRepository(ApplicationContext context) : BaseRepository<TrainComponent>(context), ITrainComponentRepository
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

        public async Task<bool> ExistsByUniqueNumberAsync(string uniqueNumber, CancellationToken cancellationToken)
        {
            var trainComponent = await _context.Set<TrainComponent>()
                .FirstOrDefaultAsync(x => x.UniqueNumber == uniqueNumber, cancellationToken);

            return trainComponent is not null;
        }

        public async Task<bool> ExistsByUniqueNumberAsync(int id, string uniqueNumber, CancellationToken cancellationToken)
        {
            var trainComponent = await _context.Set<TrainComponent>()
                .FirstOrDefaultAsync(x => x.Id != id && x.UniqueNumber == uniqueNumber, cancellationToken);

            return trainComponent is not null;
        }

        protected override IQueryable<TrainComponent> GetIncludableQueryable()
        {
            return _context.Set<TrainComponent>();
        }
    }
}
