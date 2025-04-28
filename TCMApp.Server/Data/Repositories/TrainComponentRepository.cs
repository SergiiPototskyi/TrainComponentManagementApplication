using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using TCMApp.Server.Core.Entities;
using TCMApp.Server.Core.Interfaces;
using TCMApp.Server.Data.Specifications;

namespace TCMApp.Server.Data.Repositories
{
    public class TrainComponentRepository(ApplicationContext context) : BaseRepository<TrainComponent>(context), ITrainComponentRepository
    {
        public async Task<IEnumerable<TrainComponent>> GetPaginatedListAsync(
            Specification<TrainComponent> specification,
            int pageSize,
            int pageNumber,
            string sortColumn,
            string sortOrder,
            CancellationToken cancellationToken)
        {
            var query = GetByCondition(specification);

            Expression<Func<TrainComponent, object>> keySelector = sortColumn switch
            {
                "name" => trainComponent => trainComponent.Name,
                "uniqueNumber" => trainComponent => trainComponent.UniqueNumber,
                "canAssignQuantity" => trainComponent => trainComponent.CanAssignQuantity,
                "quantity" => trainComponent => trainComponent.Quantity ?? 0,
                _ => trainComponent => trainComponent.Id
            };

            if (sortOrder == "desc")
            {
                query = query.OrderByDescending(keySelector);
            }
            else
            {
                query = query.OrderBy(keySelector);
            }

            return await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }

        public IQueryable<TrainComponent> GetByCondition(Specification<TrainComponent> specification)
        {
            return _context.Set<TrainComponent>()
                .Where(specification.ToExpression());
        }

        public int GetTotalCount(Specification<TrainComponent> specification)
        {
            return GetByCondition(specification).Count();
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

        public override async Task<IEnumerable<TrainComponent>> GetAll(Specification<TrainComponent> specification, CancellationToken cancellationToken)
        {
            return await _context.Set<TrainComponent>()
                .Where(specification.ToExpression())
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }
    }
}
