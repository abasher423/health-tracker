using System.Reflection;
using System.Text;
using Application.Abstractions;
using Application.Abstractions.Services;
using Application.API.V1.HealthDataEntry.Commands.Create;
using Application.API.V1.HealthDataEntry.Commands.Delete;
using Application.API.V1.HealthDataEntry.Commands.Update;
using Application.API.V1.HealthDataEntry.Models;
using Application.API.V1.Login.Commands;
using Application.API.V1.Login.Models;
using Application.API.V1.Profile.Commands.Create;
using Application.API.V1.Profile.Commands.Delete;
using Application.API.V1.Profile.Commands.Update;
using Application.API.V1.Profile.Models;
using Application.API.V1.Profile.Queries;
using Application.API.V1.Register.Commands;
using Application.API.V1.Register.Models;
using Application.API.V1.User.Commands.Delete;
using Application.API.V1.User.Commands.Update;
using Application.API.V1.User.Models;
using Application.API.V1.User.Queries;
using Application.API.V1.Verification.Commands;
using Application.Services;
using Microsoft.EntityFrameworkCore;
using Persistence.Configurations.Context;
using AutoMapper.EquivalencyExpression;
using HealthTracker.Mappings;
using HealthTracker.Middlewares;
using HealthTracker.OptionsSetup;
using Infrastructure;
using Infrastructure.Authentication;
using Infrastructure.EmailVerification;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Persistence;
using Persistence.Repositories.HealthDataEntries;
using Persistence.Repositories.UserProfiles;
using Persistence.Repositories.Users;


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
builder.Services.AddScoped<IHealthDataEntryRepository, HealthDataEntryRepository>();

// services
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<IVerificationService, VerificationService>();
builder.Services.AddScoped<IUserService, UserServices>();
builder.Services.AddScoped<IProfileService, ProfileService>();
builder.Services.AddScoped<IHealthDataEntryService, HealthDataEntryService>();

// commands
builder.Services.AddScoped<IRequestHandler<LoginCommand, LoginModel>, LoginCommandHandler>();
builder.Services.AddScoped<IRequestHandler<RegisterCommand, RegisterModel>, RegisterCommandHandler>();
builder.Services.AddScoped<IRequestHandler<VerifyEmailCommand, bool>, VerifyEmailCommandHandler>();
builder.Services.AddScoped<IRequestHandler<CreateProfileCommand, UserProfileModel>, CreateProfileCommandHandler>();
builder.Services.AddScoped<IRequestHandler<ProfileCommand, UserProfileModel>, ProfileCommandHandler>();
builder.Services.AddScoped<IRequestHandler<UpdateUserCommand, UserModel>, UpdateUserCommandHandler>();
builder.Services.AddScoped<IRequestHandler<DeleteProfileCommand, bool>, DeleteProfileCommandHandler>();
builder.Services.AddScoped<IRequestHandler<DeleteUserCommand, bool>, DeleteUserCommandHandler>();
builder.Services.AddScoped<IRequestHandler<CreateHealthDataEntryCommand, HealthDataEntryModel>, CreateHealthDataEntryCommandHandler>();
builder.Services.AddScoped<IRequestHandler<UpdateHealthDataEntryCommand, HealthDataEntryModel>, UpdateHealthDataEntryCommandHandler>();
builder.Services.AddScoped<IRequestHandler<DeleteHealthDataEntryCommand, bool>, DeleteHealthDataEntryCommandHandler>();

// queries
builder.Services.AddScoped<IRequestHandler<GetUserProfileQuery, UserProfileModel>, GetUserProfileQueryHandler>();
builder.Services.AddScoped<IRequestHandler<GetUserQuery, UserModel>, GetUserQueryHandler>();
builder.Services.AddScoped<IRequestHandler<ListUserProfilesQuery, IEnumerable<UserProfileModel>>, ListUserProfilesQueryHandler>();
builder.Services.AddScoped<IRequestHandler<ListUsersQuery, IEnumerable<UserModel>>, ListUsersQueryHandler>();

//builder.Services.AddScoped<IValidator<CreateUserProfileCommand>, CreateUserProfileCommandValidator>();

builder.Services.AddScoped<IJwtProvider, JwtProvider>();
builder.Services.AddScoped<IEmailVerificationProvider, EmailVerificationTokenGenerator>();
builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

var jwtOptions = builder.Configuration.GetSection("Jwt").Get<JwtOptions>();
builder.Services.Configure<JwtOptions>(options =>
{
    options.Issuer = jwtOptions.Issuer;
    options.Audience = jwtOptions.Audience;
    options.SecretKey = jwtOptions.SecretKey;
});

// JwtBearerOptionsSetup doesn't currently work (Investigate later)
// builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//    .AddJwtBearer();

// when IOptions of JwtOptions is injected, it will trigger the configure method
builder.Services.ConfigureOptions<JwtOptionsSetup>();
builder.Services.ConfigureOptions<JwtBearerOptionsSetup>();


 builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
     .AddJwtBearer(cfg =>
     {
         cfg.RequireHttpsMetadata = true;
         var key = Encoding.UTF8.GetBytes(jwtOptions.SecretKey);
         cfg.TokenValidationParameters = new TokenValidationParameters
         {
             ValidateIssuer = true,
             ValidateAudience = true,
             ValidateLifetime = true,
             ValidIssuer = jwtOptions.Issuer,
             ValidAudience = jwtOptions.Audience,
             ValidateIssuerSigningKey = true,
             ClockSkew = TimeSpan.Zero,
             IssuerSigningKey = new SymmetricSecurityKey(key)
         };
         cfg.SaveToken = true;
         
     });

builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionMiddleware();

app.UseHttpsRedirection();

// Use CORS
app.UseCors(builder =>
{
    builder.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
});

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();

