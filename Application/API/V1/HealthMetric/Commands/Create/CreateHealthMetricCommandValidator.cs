using Application.API.V1.HealthMetric.Models;
using FluentValidation;

namespace Application.API.V1.HealthMetric.Commands.Create;

public class CreateHealthMetricCommandValidator : AbstractValidator<HealthMetricModel>
{
    public CreateHealthMetricCommandValidator()
    {
        RuleFor(x => x.Type).NotNull().IsInEnum();

        RuleFor(x => x.UnitOfMeasure).NotNull().MaximumLength(200);
    }
}