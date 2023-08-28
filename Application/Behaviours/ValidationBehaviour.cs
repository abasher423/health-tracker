// using System.Windows.Input;
// using Application.Abstractions.Messaging;
// using FluentValidation;
// using MediatR;
//
// namespace Application.Behaviours;
//
// public sealed class <TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
//     where TRequest : class, ICommand<TResponse>
// {
//     private readonly IEnumerable<IValidator<TRequest>> _validators;
//     
//     public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
//     {
//         _validators = validators;
//     }
//
//     public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
//         CancellationToken cancellationToken)
//     {
//         if (!_validators.Any())
//         {
//             return await next();
//         }
//         var context = new ValidationContext<TRequest>(request);
//         var errorsDictionary = _validators
//             .Select(x => x.Validate(context))
//             .SelectMany(x => x.Errors)
//             .Where(x => x != null)
//             .GroupBy(
//                 x => x.PropertyName,
//                 x => x.ErrorMessage,
//                 (propertyName, errorMessages) => new
//                 {
//                     Key = propertyName,
//                     Values = errorMessages.Distinct().ToArray()
//                 })
//             .ToDictionary(x => x.Key, x => x.Values);
//         if (errorsDictionary.Any())
//         {
//             //throw new ValidationException(errorsDictionary);
//         }
//         return await next();
//     }
// }