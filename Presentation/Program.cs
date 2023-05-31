using System.Reflection;
using Application.API.V1.User.Commands.Create;
using Application.API.V1.User.Models;
using Application.API.V1.UserProfile.Commands.Create;
using Application.API.V1.UserProfile.Commands.Delete;
using Application.API.V1.UserProfile.Commands.Update;
using Application.API.V1.UserProfile.Models;
using Application.API.V1.UserProfile.Queries;
using Application.Repositories.User;
using Application.Repositories.UserProfile;
using Microsoft.EntityFrameworkCore;
using Persistence.Configurations.Context;
using AutoMapper.EquivalencyExpression;
using FluentValidation;
using HealthTracker.Mappings;
using MediatR;


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
    cfg.AddMaps(typeof(UserProfileProfile), typeof(UserProfile));
});

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
// builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(new Assembly[]
// {
//     Assembly.GetExecutingAssembly(),
//     typeof(CreateUserCommand).Assembly,
//     typeof(CreateUserProfileCommand).Assembly
// }));
builder.Services.AddScoped<IUserProfileRepository, UserProfileRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<IRequestHandler<CreateUserCommand, UserModel>, CreateUserCommandHandler>();
builder.Services.AddScoped<IRequestHandler<CreateUserProfileCommand, CreateUserProfileModel>, CreateUserProfileCommandHandler>();
builder.Services.AddScoped<IRequestHandler<DeleteUserProfileCommand, bool>, DeleteUserProfileCommandHandler>();
builder.Services.AddScoped<IRequestHandler<UpdateUserProfileCommand, UpdateUserProfileModel>, UpdateUserProfileCommandHandler>();

builder.Services.AddScoped<IRequestHandler<GetUserProfileQuery, UserProfileModel>, GetUserProfileQueryHandler>();
builder.Services.AddScoped<IRequestHandler<ListUserProfilesQuery, IEnumerable<UserProfileModel>>, ListUserProfilesQueryHandler>();

builder.Services.AddScoped<IValidator<CreateUserProfileCommand>, CreateUserProfileCommandValidator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

