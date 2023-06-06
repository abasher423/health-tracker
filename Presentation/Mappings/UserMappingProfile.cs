using Application.API.V1.User.Models;
using AutoMapper;
using Domain.Entities;

namespace HealthTracker.Mappings;

public class UserMappingProfile : Profile
{
    public UserMappingProfile()
    {
        CreateMap<User, UserModel>();
        CreateMap<User, UpdateUserModel>();
    }
}