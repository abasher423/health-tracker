using Application.API.V1.UserProfile.Models;
using Application.API.V1.UserProfile.Queries;
using Application.API.V1.UserProfile;
using Application.Repositories.UserProfile;
using Common.Enums;
using Moq;

namespace Tests.Application.API.UserProfile.Queries;

public class GetUserProfileQueryHandlerTests
{
    private readonly Mock<IUserProfileRepository> _userProfileRepositoryMock;
    
    public GetUserProfileQueryHandlerTests()
    {
        _userProfileRepositoryMock = new Mock<IUserProfileRepository>();
    }

    [Fact]
    public async Task Handle_Should_ThrowArgumentNullException_WhenNullRequest()
    {
        // Arrange
        var handler = new GetUserProfileQueryHandler(_userProfileRepositoryMock.Object);
        
        // Act and Assert
        await Assert.ThrowsAsync<ArgumentNullException>(async () =>
        {
             await handler.Handle(null, default);
        });
    }

    [Fact]
    public async Task Handle_Should_ThrowArgumentNullException_WhenEmptyRequestId()
    {
        // Arrange
        var id = Guid.Empty;
        var query = new GetUserProfileQuery(id);
        var handler = new GetUserProfileQueryHandler(_userProfileRepositoryMock.Object);
        
        // Act and Assert
        await Assert.ThrowsAsync<ArgumentNullException>(async () =>
        {
            await handler.Handle(query, default);
        });
    }

    [Fact]
    public async Task Handle_Should_ThrowArgumentNullException_WhenRequestIsNull()
    {
        // Arrange
        var id = Guid.NewGuid();
        var query = new GetUserProfileQuery(id);
        var handler = new GetUserProfileQueryHandler(_userProfileRepositoryMock.Object);
        
        var userProfile = new UserProfileModel()
        {
            Id = id,
            Age = 27,
            Gender = Gender.Male,
            Height = 179,
            Weight = 75
        };

        _userProfileRepositoryMock.Setup(
                x => x.GetSingleUserProfile(id, It.IsAny<CancellationToken>()))
            .ReturnsAsync(userProfile);

        // Act
        var result = await handler.Handle(query, default);

        // Assert
        Assert.Equal(userProfile, result);
    }
}