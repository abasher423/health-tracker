using Application.API.V1.UserProfile.Commands.Update;
using Application.API.V1.UserProfile.Models;
using AutoMapper;
using Domain.Entities;

namespace HealthTracker.Mappings;

public class UserProfileMappingProfile : Profile
{
    public UserProfileMappingProfile()
    {
        CreateMap<UserProfile, UserProfileModel>().ReverseMap();
        CreateMap<UserProfile, CreateUserProfileModel>().ReverseMap();
        CreateMap<UserProfile, UpdateUserProfileModel>().ReverseMap();
        
        CreateMap<UpdateUserProfileCommand, UpdateUserProfileModel>().ReverseMap();
    }
}