using MediatR;
using TCMApp.Server.Core;
using TCMApp.Server.Core.Entities;
using TCMApp.Server.Core.Interfaces;
using TCMApp.Server.UseCases.Models;

namespace TCMApp.Server.UseCases.GetTrainComponent
{
    public class GetTrainComponentHandler(
        ITrainComponentRepository repository,
        IMapper<TrainComponent, TrainComponentResponse> mapper)
        : IRequestHandler<GetTrainComponentRequest, Result<TrainComponentResponse>>
    {
        public async Task<Result<TrainComponentResponse>> Handle(GetTrainComponentRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await repository.GetByIdAsync(request.Id, cancellationToken);
                if (result is null)
                {
                    return Result<TrainComponentResponse>.Failure("Train component not found");
                }
                return Result<TrainComponentResponse>.Success(mapper.Map(result));
            }
            catch (Exception ex)
            {
                return Result<TrainComponentResponse>.Failure(ex.Message);
            }
        }
    }

    public record GetTrainComponentRequest(int Id) : IRequest<Result<TrainComponentResponse>>;
}