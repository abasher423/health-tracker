using Application.API.V1.UserProfiles;
using Application.API.V1.UserProfiles.Models;
using Application.API.V1.UserProfiles.Queries;
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
    public async Task Handle_WhenRequestIsValid_ReturnsSingleUserProfile()
    {
        // Arrange
        var id = Guid.NewGuid();
        var query = new GetUserProfileQuery(id);
        var handler = new GetUserProfileQueryHandler(_userProfileRepositoryMock.Object);
        
        var userProfile = new UserProfileDto()
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

    [Fact]
    public async Task Handle_WhenNullRequest_ReturnsNull()
    {
        // Arrange
        UserProfileDto userProfile = null;
        var query = new GetUserProfileQuery(Guid.NewGuid());
        var handler = new GetUserProfileQueryHandler(_userProfileRepositoryMock.Object);

        _userProfileRepositoryMock.Setup(
                x => x.GetSingleUserProfile(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(userProfile);
        
        // Act
        var result = await handler.Handle(query, default);
        
        // Assert
        Assert.Null(result);
    }
}