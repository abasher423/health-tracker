using Application.Abstractions.Messaging;
using Application.API.V1.User.Models;

namespace Application.API.V1.User.Queries;

public class GetUserQuery : IQuery<UserModel>
{
    public Guid Id { get; set; }
    
    public GetUserQuery(Guid id)
    {
        Id = id;
    }
}