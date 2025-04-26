using FluentValidation;
using MediatR;
using TCMApp.Server.Core;
using TCMApp.Server.Core.Entities;
using TCMApp.Server.Core.Interfaces;
using TCMApp.Server.UseCases.Models;

namespace TCMApp.Server.UseCases.UpdateTrainComponent
{
    public class UpdateTrainComponentHandler(
        ITrainComponentRepository repository,
        IMapper<TrainComponent, TrainComponentResponse> mapper,
        IValidator<UpdateTrainComponentRequest> validator,
        IUnitOfWork unitOfWork)
        : IRequestHandler<UpdateTrainComponentRequest, Result<TrainComponentResponse>>
    {
        public async Task<Result<TrainComponentResponse>> Handle(UpdateTrainComponentRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var validationResult = validator.Validate(request);
                if (!validationResult.IsValid)
                {
                    return Result<TrainComponentResponse>.Failure(validationResult.Errors);
                }

                var trainComponent = await repository.GetByIdAsync(request.Id, cancellationToken);
                if (trainComponent is null)
                {
                    return Result<TrainComponentResponse>.Failure("Train component not found.");
                }

                trainComponent.SetName(request.Name);
                trainComponent.SetUniqueNumber(request.UniqueNumber);
                trainComponent.AssignQuantity(request.CanAssignQuantity, request.Quantity);

                repository.Update(trainComponent);
                await unitOfWork.SaveChangesAsync(cancellationToken);

                return Result<TrainComponentResponse>.Success(mapper.Map(trainComponent));
            }
            catch (Exception ex)
            {
                return Result<TrainComponentResponse>.Failure(ex.Message);
            }
        }
    }

    public record UpdateTrainComponentRequest(int Id) : TrainComponentBase, IRequest<Result<TrainComponentResponse>>;
}
