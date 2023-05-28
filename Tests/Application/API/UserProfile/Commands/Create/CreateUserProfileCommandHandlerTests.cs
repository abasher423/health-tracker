using Application.API.V1.UserProfiles;
using Application.API.V1.UserProfiles.Commands.Create;
using Application.API.V1.UserProfiles.Models;
using Application.Repositories.UserProfile;
using Common.Enums;
using Moq;

namespace Tests.Application.API.UserProfile.Commands.Create;

public class CreateUserProfileCommandHandlerTests
{
    private readonly Mock<IUserProfileRepository> _userProfileRepositoryMock;

    public CreateUserProfileCommandHandlerTests()
    {
        _userProfileRepositoryMock = new Mock<IUserProfileRepository>();
    }

    [Fact]
    public async Task Handle_Should_ThrowArgumentNullException_WhenRequestIsNull()
    {
        // Arrange
        var handler = new CreateUserProfileCommandHandler(_userProfileRepositoryMock.Object);
        
        // Act and Assert
        await Assert.ThrowsAsync<ArgumentNullException>(async () =>
        {
            await handler.Handle(null, default);
        });
    }

    [Fact]
    public async Task Handle_Should_ReturnCreateUserProfileDto_WhenValidRequest()
    {
        // Arrange
        var handler = new CreateUserProfileCommandHandler(_userProfileRepositoryMock.Object);

        var command = new CreateUserProfileCommand()
        {
            Id = new Guid(),
            Age = 27,
            Gender = Gender.Male,
            Height = 175,
            Weight = 128
        };

        var createUserProfileDto = new CreateUserProfileDto()
        {
            Id = new Guid(),
            Age = 27,
            Gender = Gender.Male,
            Height = 175,
            Weight = 128
        };

        _userProfileRepositoryMock.Setup(
                x => x.CreateUserProfile(command, It.IsAny<CancellationToken>()))
            .ReturnsAsync(createUserProfileDto);

        // Act
        var result = await handler.Handle(command, default);

        // Assert
        Assert.Equal(createUserProfileDto, result);
    }
}