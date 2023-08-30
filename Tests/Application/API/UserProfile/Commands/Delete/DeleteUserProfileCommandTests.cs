using Application.API.V1.Profile.Commands.Delete;

namespace Tests.Application.API.UserProfile.Commands.Delete;

public class DeleteUserProfileCommandTests
{
    [Fact]
    public void Ctor_Property_ShouldBeSetCorrectly()
    {
        // Arrange
        var id = Guid.NewGuid();

        // Act
        var command = new DeleteProfileCommand(id);
        
        // Assert
        Assert.Equal(id, command.Id);
    }
}