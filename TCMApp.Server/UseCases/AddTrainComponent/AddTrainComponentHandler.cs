using FluentValidation;
using MediatR;
using TCMApp.Server.Core;
using TCMApp.Server.Core.Entities;
using TCMApp.Server.Core.Interfaces;
using TCMApp.Server.UseCases.Models;

namespace TCMApp.Server.UseCases.AddTrainComponent
{
    public class AddTrainComponentHandler(
        ITrainComponentRepository repository,
        IMapper<TrainComponent, TrainComponentResponse> mapper,
        IValidator<AddTrainComponentRequest> validator,
        IUnitOfWork unitOfWork)
        : IRequestHandler<AddTrainComponentRequest, Result<TrainComponentResponse>>
    {
        public async Task<Result<TrainComponentResponse>> Handle(AddTrainComponentRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var validationResult = await validator.ValidateAsync(request, cancellationToken);
                if (!validationResult.IsValid)
                {
                    return Result<TrainComponentResponse>.Failure(validationResult.Errors);
                }

                var trainComponent = new TrainComponent(request.Name, request.UniqueNumber, request.CanAssignQuantity, request.Quantity);

                repository.Add(trainComponent);
                await unitOfWork.SaveChangesAsync(cancellationToken);

                var result = await repository.GetByIdAsync(trainComponent.Id, cancellationToken);

                return Result<TrainComponentResponse>.Success(mapper.Map(result!));
            }
            catch (Exception ex)
            {
                return Result<TrainComponentResponse>.Failure(ex.Message);
            }
        }
    }

    public record AddTrainComponentRequest : TrainComponentBase, IRequest<Result<TrainComponentResponse>>;
}
