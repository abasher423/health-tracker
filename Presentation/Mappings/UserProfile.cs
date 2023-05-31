using Application.API.V1.User.Models;
using AutoMapper;
using Domain.Entities;

namespace HealthTracker.Mappings;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, UserModel>();
        CreateMap<User, UpdateUserModel>();
    }
}