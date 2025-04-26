using TCMApp.Server.UseCases.Models;

namespace TCMApp.Server.Core.Interfaces
{
    public interface ITrainComponentService
    {
        Task<IReadOnlyCollection<TrainComponentBase>> GetTrainComponentsAsync(CancellationToken cancellationToken);
    }
}