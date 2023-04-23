using Application.API.V1.UserProfiles.Models;
using MediatR;

namespace Application.API.V1.UserProfiles.Queries;

public class ListUserProfilesQuery : IRequest<IEnumerable<UserProfileDto>>
{
}