using FluentValidation;
using TCMApp.Application.UseCases.Models;

namespace TCMApp.Application.UseCases.Validators;

public class BaseTrainComponentRequestValidator<T> : AbstractValidator<T> where T : TrainComponentBase
{
    public BaseTrainComponentRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name is required");

        RuleFor(x => x.CanAssignQuantity)
            .NotNull()
            .WithMessage("CanAssignQuantity is required");

        RuleFor(x => x.Quantity)
            .NotNull().When(x => x.CanAssignQuantity == true)
            .WithMessage("Quantity must be a positive number")
            .GreaterThan(0).When(x => x.CanAssignQuantity == true)
            .WithMessage("Quantity must be a positive number");

        RuleFor(x => x.Quantity)
            .Must(x => x is null)
            .When(x => !x.CanAssignQuantity)
            .WithMessage("Cannot set Quantity when CanAssignQuantity is false");
    }
}
