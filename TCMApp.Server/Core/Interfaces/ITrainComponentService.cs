using TCMApp.Server.Core.Contracts;

namespace TCMApp.Server.Core.Interfaces;

public interface ITrainComponentService
{
    Task<IReadOnlyCollection<TrainComponentContract>> GetTrainComponentsAsync(CancellationToken cancellationToken);
}