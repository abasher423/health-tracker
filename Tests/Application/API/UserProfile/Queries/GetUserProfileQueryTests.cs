// using Application.API.V1.UserProfile.Queries;
// using Application.API.V1.UserProfile;
// using Moq;
//
// namespace Tests.Application.API.UserProfile.Queries;
//
// public class GetUserProfileQueryTests
// {
//     private readonly Mock<IUserProfileRepository> _userProfileRepositoryMock;
//
//     public GetUserProfileQueryTests()
//     {
//         _userProfileRepositoryMock = new Mock<IUserProfileRepository>();
//     }
//
//     [Fact]
//     public void GetUserProfileQuery_Properties_ShouldBeSetCorrectly()
//     {
//         // Arrange
//         var id = Guid.NewGuid();
//         
//         // Act
//         var query = new GetUserProfileQuery(id);
//         
//         // Assert
//         Assert.Equal(id, query.Id);
//     }
// }