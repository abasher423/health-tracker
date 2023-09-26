using Application.API.V1.HealthDataEntry.Models;
using FluentValidation;

namespace Application.API.V1.HealthDataEntry.Commands.Create;

public class CreateHealthDataEntryCommandValidator : AbstractValidator<CreateHealthDataEntryModel>
{
    public CreateHealthDataEntryCommandValidator()
    {
        RuleFor(x => x.UserId).NotNull();

        RuleFor(x => x.HealthMetricId).NotNull();

        RuleFor(x => x.Name).NotNull().IsInEnum();

        RuleFor(x => x.Value).InclusiveBetween(0, 100000000).NotNull();
    }
}