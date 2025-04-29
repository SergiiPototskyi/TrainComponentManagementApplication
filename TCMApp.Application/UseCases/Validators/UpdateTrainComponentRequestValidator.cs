using FluentValidation;
using TCMApp.Application.UseCases.UpdateTrainComponent;
using TCMApp.Core.Interfaces;

namespace TCMApp.Application.UseCases.Validators;

public class UpdateTrainComponentRequestValidator : BaseTrainComponentRequestValidator<UpdateTrainComponentRequest>
{
    private readonly ITrainComponentRepository _repository;

    public UpdateTrainComponentRequestValidator(ITrainComponentRepository repository)
    {
        _repository = repository;

        RuleFor(x => x)
            .NotEmpty()
            .WithMessage("UniqueNumber is required")
            .MustAsync(BeUniqueUniqueNumber)
            .WithMessage("Unique Number is already in use");
    }

    private async Task<bool> BeUniqueUniqueNumber(UpdateTrainComponentRequest request, CancellationToken cancellationToken)
    {
        return !await _repository.ExistsByUniqueNumberAsync(request.Id, request.UniqueNumber, cancellationToken);
    }
}
