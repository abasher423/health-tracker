using Application.Abstractions.Messaging;
using Application.API.V1.UserProfile.Models;

namespace Application.API.V1.UserProfile.Queries;

public class ListUserProfilesQuery : IQuery<IEnumerable<UserProfileModel>>
{
}