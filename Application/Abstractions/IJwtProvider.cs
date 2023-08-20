using Application.API.V1.User.Models;

namespace Application.Abstractions;

public interface IJwtProvider
{
    string Generate(UserModel user);
}