using System.Reflection;
using Application.API.V1.UserProfiles.Commands;
using Application.API.V1.UserProfiles.Models;
using Application.API.V1.UserProfiles.Queries;
using Application.Mapping;
using Microsoft.EntityFrameworkCore;
using Persistence.Configurations.Context;
using AutoMapper.EquivalencyExpression;
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
    cfg.AddMaps(typeof(UserProfilesProfile));
});

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

builder.Services.AddScoped<IRequestHandler<CreateUserProfileCommand, CreateUserProfileDto>, CreateUserProfileCommandHandler>();
builder.Services.AddScoped<IRequestHandler<DeleteUserProfileCommand, bool>, DeleteUserProfileCommandHandler>();
builder.Services.AddScoped<IRequestHandler<UpdateUserProfileCommand, UpdateUserProfileDto>, UpdateUserProfileCommandHandler>();

builder.Services.AddScoped<IRequestHandler<GetUserProfileQuery, UserProfileDto>, GetUserProfileQueryHandler>();
builder.Services.AddScoped<IRequestHandler<ListUserProfilesQuery, IEnumerable<UserProfileDto>>, ListUserProfilesQueryHandler>();

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

