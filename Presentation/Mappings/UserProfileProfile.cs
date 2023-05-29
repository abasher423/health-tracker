using Application.API.V1.UserProfile.Models;
using AutoMapper;
using Domain.Entities;
using HealthTracker.DTOs.UserProfile;

namespace HealthTracker.Mappings;

public class UserProfileProfile : Profile
{
    public UserProfileProfile()
    {
        CreateMap<UserProfile, UserProfileModel>().ReverseMap();
        CreateMap<UserProfile, CreateUserProfileModel>().ReverseMap();
        CreateMap<UserProfile, UpdateUserProfileModel>().ReverseMap();

        CreateMap<UserProfileModel, UserProfileDto>().ReverseMap();
        CreateMap<CreateUserProfileModel, CreateUserProfileDto>().ReverseMap();
        CreateMap<UpdateUserProfileModel, UpdateUserProfileDto>().ReverseMap();
    }
}