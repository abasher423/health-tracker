using System.Reflection;
using Application.Abstractions;
using Application.API.V1.Login.Commands;
using Application.API.V1.Login.Models;
using Application.API.V1.Register.Commands;
using Application.API.V1.Register.Models;
using Application.API.V1.User.Commands.Delete;
using Application.API.V1.User.Commands.Update;
using Application.API.V1.User.Models;
using Application.API.V1.User.Queries;
using Application.API.V1.UserProfile.Commands.Create;
using Application.API.V1.UserProfile.Commands.Delete;
using Application.API.V1.UserProfile.Commands.Update;
using Application.API.V1.UserProfile.Models;
using Application.API.V1.UserProfile.Queries;
using Application.Repositories.User;
using Application.Repositories.UserProfile;
using Application.Services.Implementations;
using Application.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Configurations.Context;
using AutoMapper.EquivalencyExpression;
using FluentValidation;
using HealthTracker.Mappings;
using HealthTracker.OptionsSetup;
using Infrastructure;
using Infrastructure.Authentication;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;


var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("health");

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// register dbContext
builder.Services.AddDbContext<HealthTrackerDbContext>(
    options => options.UseNpgsql((connectionString)));

builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddCollectionMappers();
    cfg.AddMaps(typeof(UserProfileMappingProfile), typeof(UserMappingProfile), typeof(LoginMappingProfile));
});

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

// repositories
builder.Services.AddScoped<IUserProfileRepository, UserProfileRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

// services
builder.Services.AddScoped<IAccountService, AccountService>();

// commands
builder.Services.AddScoped<IRequestHandler<LoginCommand, LoginModel>, LoginCommandHandler>();
builder.Services.AddScoped<IRequestHandler<RegisterCommand, RegisterModel>, RegisterCommandHandler>();
builder.Services.AddScoped<IRequestHandler<CreateUserProfileCommand, CreateUserProfileModel>, CreateUserProfileCommandHandler>();
builder.Services.AddScoped<IRequestHandler<UpdateUserProfileCommand, UpdateUserProfileModel>, UpdateUserProfileCommandHandler>();
builder.Services.AddScoped<IRequestHandler<UpdateUserCommand, UpdateUserModel>, UpdateUserCommandHandler>();
builder.Services.AddScoped<IRequestHandler<DeleteUserProfileCommand, bool>, DeleteUserProfileCommandHandler>();
builder.Services.AddScoped<IRequestHandler<DeleteUserCommand, bool>, DeleteUserCommandHandler>();

// queries
builder.Services.AddScoped<IRequestHandler<GetUserProfileQuery, UserProfileModel>, GetUserProfileQueryHandler>();
builder.Services.AddScoped<IRequestHandler<GetUserQuery, UserModel>, GetUserQueryHandler>();
builder.Services.AddScoped<IRequestHandler<ListUserProfilesQuery, IEnumerable<UserProfileModel>>, ListUserProfilesQueryHandler>();
builder.Services.AddScoped<IRequestHandler<ListUsersQuery, IEnumerable<UserModel>>, ListUsersQueryHandler>();

builder.Services.AddScoped<IValidator<CreateUserProfileCommand>, CreateUserProfileCommandValidator>();

// Authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer();

builder.Services.AddScoped<IJwtProvider, JwtProvider>();
builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();

var jwtOptions = builder.Configuration.GetSection("Jwt").Get<JwtOptions>();
builder.Services.Configure<JwtOptions>(options =>
{
    options.Issuer = jwtOptions.Issuer;
    options.Audience = jwtOptions.Audience;
    options.SecretKey = jwtOptions.SecretKey;
});


// when IOptions of JwtOptions is injected, it will trigger the configure method
builder.Services.ConfigureOptions<JwtOptionsSetup>();
builder.Services.ConfigureOptions<JwtBearerOptionsSetup>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();

