using Application.API.V1.HealthMetric.Models;
using FluentValidation;

namespace Application.API.V1.HealthMetric.Commands.Update;

public class UpdateHealthMetricCommandValidator: AbstractValidator<HealthMetricModel>
{
    public UpdateHealthMetricCommandValidator()
    {
        RuleFor(x => x.Id).NotNull();

        RuleFor(x => x.Type).NotNull().IsInEnum();

        RuleFor(x => x.UnitOfMeasure).NotNull().MaximumLength(200);
    }
}