using FluentValidation;
using TCMApp.Server.Core.Interfaces;
using TCMApp.Server.UseCases.AddTrainComponent;

namespace TCMApp.Server.UseCases.Validators;

public class AddTrainComponentRequestValidator : BaseTrainComponentRequestValidator<AddTrainComponentRequest>
{
    private readonly ITrainComponentRepository _repository;

    public AddTrainComponentRequestValidator(ITrainComponentRepository repository)
    {
        _repository = repository;

        RuleFor(x => x.UniqueNumber)
            .NotEmpty()
            .WithMessage("UniqueNumber is required")
            .MustAsync(BeUniqueUniqueNumber)
            .WithMessage("Unique Number is already in use");
    }

    private async Task<bool> BeUniqueUniqueNumber(string uniqueNumber, CancellationToken cancellationToken)
    {
        return !await _repository.ExistsByUniqueNumberAsync(uniqueNumber, cancellationToken);
    }
}
