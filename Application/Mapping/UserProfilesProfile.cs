using Application.API.V1.UserProfiles.Models;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapping;

public class UserProfilesProfile : Profile
{
    public UserProfilesProfile()
    {
        CreateMap<UserProfile, UserProfileDto>().ReverseMap();
        CreateMap<UserProfile, CreateUserProfileDto>().ReverseMap();
        CreateMap<UserProfile, UpdateUserProfileDto>().ReverseMap();
    }
}