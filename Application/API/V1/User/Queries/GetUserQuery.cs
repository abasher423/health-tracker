using Application.API.V1.User.Models;
using MediatR;

namespace Application.API.V1.User.Queries;

public class GetUserQuery : IRequest<UserModel>
{
    public Guid Id { get; set; }
    
    public GetUserQuery(Guid id)
    {
        Id = id;
    }
}