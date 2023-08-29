using Application.Abstractions.Messaging;
using Application.API.V1.Profile.Models;

namespace Application.API.V1.Profile.Queries;

public class ListUserProfilesQuery : IQuery<IEnumerable<UserProfileModel>>
{
}