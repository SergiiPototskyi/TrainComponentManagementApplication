using TCMApp.Server.Core.Entities;
using TCMApp.Server.Data.Specifications;

namespace TCMApp.Server.Core.Interfaces;

public interface ITrainComponentRepository
{
    Task<bool> ExistsByUniqueNumberAsync(string uniqueNumber, CancellationToken cancellationToken);
    Task<bool> ExistsByUniqueNumberAsync(int id, string uniqueNumber, CancellationToken cancellationToken);
    Task<IEnumerable<TrainComponent>> GetAll(Specification<TrainComponent> specification, CancellationToken cancellationToken); 
    Task<TrainComponent?> GetByIdAsync(int id, CancellationToken cancellationToken);
    void Add(TrainComponent trainComponent);
    void Update(TrainComponent trainComponent);
    void Delete(TrainComponent trainComponent);
}