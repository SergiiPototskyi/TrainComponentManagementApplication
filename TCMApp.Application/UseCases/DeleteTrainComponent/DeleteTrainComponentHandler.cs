using MediatR;
using TCMApp.Core;
using TCMApp.Core.Interfaces;

namespace TCMApp.Application.UseCases.DeleteTrainComponent
{
    public class DeleteTrainComponentHandler(ITrainComponentRepository repository, IUnitOfWork unitOfWork)
        : IRequestHandler<DeleteTrainComponentRequest, Result<DeleteTrainComponentResponse>>
    {
        public async Task<Result<DeleteTrainComponentResponse>> Handle(DeleteTrainComponentRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var trainComponent = await repository.GetByIdAsync(request.Id, cancellationToken);
                if (trainComponent is null)
                {
                    return Result<DeleteTrainComponentResponse>.Failure("Train component not found");
                }
                repository.Delete(trainComponent);
                await unitOfWork.SaveChangesAsync(cancellationToken);

                return Result<DeleteTrainComponentResponse>.Success(new DeleteTrainComponentResponse(request.Id));
            }
            catch (Exception ex)
            {
                return Result<DeleteTrainComponentResponse>.Failure(ex.Message);
            }
        }
    }

    public record DeleteTrainComponentRequest(int Id) : IRequest<Result<DeleteTrainComponentResponse>>;
    public record DeleteTrainComponentResponse(int Id);
}