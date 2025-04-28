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
                var searchSpecification = new SearchSpecification(request.Search);
                var trainComponents = await repository.GetPaginatedListAsync(
                    searchSpecification, 
                    request.PageSize,
                    request.PageNumber,
                    request.SortColumn,
                    request.SortOrder,
                    cancellationToken);

                var totalCount = repository.GetTotalCount(searchSpecification);

                var result = new GetTrainComponentListResponse(totalCount, trainComponents.Select(mapper.Map));
                return Result<GetTrainComponentListResponse>.Success(result);
            }
            catch (Exception ex)
            {
                return Result<GetTrainComponentListResponse>.Failure(ex.Message);
            }
        }
    }

    public record GetTrainComponentListRequest(
        string? Search = null,
        int PageSize = 10,
        int PageNumber = 1,
        string SortColumn = nameof(TrainComponent.Name),
        string SortOrder = "asc") : IRequest<Result<GetTrainComponentListResponse>>;

    public record GetTrainComponentListResponse(int TotalCount, IEnumerable<TrainComponentResponse> Data);
}