using TCMApp.Core.Entities;
using TCMApp.Core.Specifications;

namespace TCMApp.Core.Interfaces;

public interface ITrainComponentRepository
{
    Task<bool> ExistsByUniqueNumberAsync(string uniqueNumber, CancellationToken cancellationToken);
    Task<bool> ExistsByUniqueNumberAsync(int id, string uniqueNumber, CancellationToken cancellationToken);
    Task<IEnumerable<TrainComponent>> GetAll(Specification<TrainComponent> specification, CancellationToken cancellationToken); 
    Task<TrainComponent?> GetByIdAsync(int id, CancellationToken cancellationToken);
    void Add(TrainComponent trainComponent);
    void Update(TrainComponent trainComponent);
    void Delete(TrainComponent trainComponent);
    Task<IEnumerable<TrainComponent>> GetPaginatedListAsync(
            Specification<TrainComponent> specification,
            int pageSize,
            int pageNumber,
            string sortColumn,
            string sortOrder,
            CancellationToken cancellationToken);

    IQueryable<TrainComponent> GetByCondition(Specification<TrainComponent> specification);
    int GetTotalCount(Specification<TrainComponent> specification);
}