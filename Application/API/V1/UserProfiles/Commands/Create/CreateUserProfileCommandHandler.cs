using Application.API.V1.UserProfiles.Models;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Persistence.Configurations.Context;

namespace Application.API.V1.UserProfiles.Commands.Create;

public class CreateUserProfileCommandHandler : IRequestHandler<CreateUserProfileCommand, CreateUserProfileDto>
{
    private readonly HealthTrackerDbContext _context;
    private readonly IMapper _mapper;

    public CreateUserProfileCommandHandler(HealthTrackerDbContext context, IMediator mediator, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<CreateUserProfileDto> Handle(CreateUserProfileCommand request, CancellationToken cancellationToken)
    {
        if (request == null)
        {
            throw new ArgumentNullException();
        }

        var userProfile = new UserProfile()
        {
            Id = new Guid(),
            Age = request.Age,
            Gender = request.Gender,
            Height = request.Height,
            Weight = request.Weight
        };
        
        await _context.UserProfiles.AddAsync(userProfile, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        
        return _mapper.Map<CreateUserProfileDto>(userProfile);
    }
}