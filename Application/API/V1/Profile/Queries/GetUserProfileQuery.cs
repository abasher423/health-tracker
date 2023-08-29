using Application.Abstractions.Messaging;
using Application.API.V1.Profile.Models;

namespace Application.API.V1.Profile.Queries;

public class GetUserProfileQuery : IQuery<UserProfileModel>
{
    public Guid Id { get; set; }
    public GetUserProfileQuery(Guid id)
    {
        Id = id;
    }
}