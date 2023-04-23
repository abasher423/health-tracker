using Application.API.V1.UserProfiles.Models;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Configurations.Context;

namespace Application.API.V1.UserProfiles.Commands.Update;

public class UpdateUserProfileCommandHandler : IRequestHandler<UpdateUserProfileCommand, UpdateUserProfileDto>
{
    private readonly HealthTrackerDbContext _context;
    private readonly IMapper _mapper;

    public UpdateUserProfileCommandHandler(HealthTrackerDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public async Task<UpdateUserProfileDto> Handle(UpdateUserProfileCommand request, CancellationToken cancellationToken)
    {
        var userProfileToUpdate = _context.UserProfiles.FirstOrDefault(x => x.Id == request.Id);

        if (userProfileToUpdate == null)
        {
            throw new Exception("User Profile with that Id does not exist. Unable to Delete.");
        }

        userProfileToUpdate.Gender = request.Gender;
        userProfileToUpdate.Age = request.Age;
        userProfileToUpdate.Height = request.Height;
        userProfileToUpdate.Weight = request.Weight;

        _context.Entry(userProfileToUpdate).State = EntityState.Modified;
        await _context.SaveChangesAsync(cancellationToken);

        return _mapper.Map<UpdateUserProfileDto>(userProfileToUpdate);
    }
}