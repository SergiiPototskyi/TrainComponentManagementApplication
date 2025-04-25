using TCMApp.Server.Core.Contracts;
using TCMApp.Server.Core.Entities;
using TCMApp.Server.Core.Interfaces;
using TCMApp.Server.Data.Specifications;

namespace TCMApp.Server.Services;

public class TrainComponentService(
    IRepository<TrainComponent> repository,
    IMapper<TrainComponent, TrainComponentContract> mapper) : ITrainComponentService
{
    public async Task<IReadOnlyCollection<TrainComponentContract>> GetTrainComponentsAsync(CancellationToken cancellationToken)
    {
        var result = await repository.GetAll(new DefaultSpecification<TrainComponent>(), cancellationToken);

        return [.. result.Select(mapper.Map)];
    }
}
