using Application.API.V1.Profile.Commands.Create;
using Application.API.V1.Profile.Models;
using AutoMapper;
using Domain.Entities;

namespace HealthTracker.Mappings;

public class UserProfileMappingProfile : Profile
{
    public UserProfileMappingProfile()
    {
        CreateMap<CreateProfileCommand, UserProfileModel>().ReverseMap();

        CreateMap<UserProfileModel, UserProfile>().ReverseMap();
    }
}