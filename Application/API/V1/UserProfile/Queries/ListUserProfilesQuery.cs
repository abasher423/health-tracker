using Application.API.V1.UserProfile.Models;
using MediatR;

namespace Application.API.V1.UserProfile.Queries;

public class ListUserProfilesQuery : IRequest<IEnumerable<UserProfileModel>>
{
}