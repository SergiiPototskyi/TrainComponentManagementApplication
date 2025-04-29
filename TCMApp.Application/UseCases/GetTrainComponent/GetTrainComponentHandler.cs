using MediatR;
using TCMApp.Application.UseCases.Models;
using TCMApp.Core;
using TCMApp.Core.Entities;
using TCMApp.Core.Interfaces;

namespace TCMApp.Application.UseCases.GetTrainComponent
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