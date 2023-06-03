using Application.API.V1.UserProfile.Commands.Create;
using Common.Enums;

namespace Tests.Application.API.UserProfile.Commands.Create;

public class CreateUserProfileCommandTests
{
    [Fact]
    public void Ctor_Properties_ShouldBeSetCorrectly()
    {
        // Arrange
        var id = new Guid();
        
        // Act
        var command = new CreateUserProfileCommand()
        {
            Id = id,
            Age = 25,
            Gender = Gender.Female,
            Height = 155.5m,
            Weight = 65.2m
        };
        
        // Assert
        Assert.Equal(id, command.Id);
        Assert.Equal(25, command.Age);
        Assert.Equal(Gender.Female, command.Gender);
        Assert.Equal(155.5m, command.Height);
        Assert.Equal(65.2m, command.Weight);
    }
}