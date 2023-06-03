using Application.API.V1.UserProfile.Models;
using MediatR;

namespace Application.API.V1.UserProfile.Queries;

public class GetUserProfileQuery : IRequest<UserProfileModel>
{
    public Guid Id { get; set; }
    public GetUserProfileQuery(Guid id)
    {
        Id = id;
    }
}