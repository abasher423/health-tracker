using Application.API.V1.HealthDataEntry.Models;
using FluentValidation;

namespace Application.API.V1.HealthDataEntry.Commands.Update;

public class UpdateHealthDataEntryCommandValidator : AbstractValidator<UpdateHealthDataEntryModel>
{
    public UpdateHealthDataEntryCommandValidator()
    {
        RuleFor(x => x.UserId).NotNull();

        RuleFor(x => x.HealthMetricId).NotNull();

        RuleFor(x => x.Name).NotNull().IsInEnum();

        RuleFor(x => x.Value).InclusiveBetween(0, 100000000).NotNull();
    }
}