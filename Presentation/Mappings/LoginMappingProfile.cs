using Application.API.V1.Login.Commands;
using Application.API.V1.Login.Models;
using Application.API.V1.Register.Commands;
using Application.API.V1.Register.Models;
using AutoMapper;
using HealthTracker.DTOs.Login;

namespace HealthTracker.Mappings;

public class LoginMappingProfile : Profile
{
    public LoginMappingProfile()
    {
        CreateMap<LoginCommand, LoginRequest>().ReverseMap();
        CreateMap<RegisterCommand, RegisterRequest>().ReverseMap();

        CreateMap<RegisterModel, LoginDto>().ReverseMap();
        CreateMap<LoginModel, LoginDto>().ReverseMap();
    }
}