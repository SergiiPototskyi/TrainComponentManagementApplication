using MediatR;
using TCMApp.Server.Core;
using TCMApp.Server.Core.Entities;
using TCMApp.Server.Core.Interfaces;
using TCMApp.Server.Data.Specifications;
using TCMApp.Server.UseCases.Models;

namespace TCMApp.Server.UseCases.GetTrainComponentList
{
    public class GetTrainComponentListHandler(
        ITrainComponentRepository repository,
        IMapper<TrainComponent, TrainComponentResponse> mapper)
        : IRequestHandler<GetTrainComponentListRequest, Result<GetTrainComponentListResponse>>
    {
        public async Task<Result<GetTrainComponentListResponse>> Handle(GetTrainComponentListRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await repository.GetAll(new DefaultSpecification<TrainComponent>(), cancellationToken);
                return Result<GetTrainComponentListResponse>.Success(new GetTrainComponentListResponse(result.Select(mapper.Map)));
            }
            catch (Exception ex)
            {
                return Result<GetTrainComponentListResponse>.Failure(ex.Message);
            }
        }
    }

    public record GetTrainComponentListRequest(string? Search = null) : IRequest<Result<GetTrainComponentListResponse>>;

    public record GetTrainComponentListResponse(IEnumerable<TrainComponentResponse> TrainComponents);
}