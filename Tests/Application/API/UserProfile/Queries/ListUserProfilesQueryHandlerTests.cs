// using Application.API.V1.UserProfile.Models;
// using Application.API.V1.UserProfile.Queries;
// using Application.API.V1.UserProfile;
// using Common.Enums;
// using Moq;
//
// namespace Tests.Application.API.UserProfile.Queries;
//
// public class ListUserProfilesQueryHandlerTests
// {
//     private readonly Mock<IUserProfileRepository> _userProfileRepositoryMock;
//
//     public ListUserProfilesQueryHandlerTests()
//     {
//         _userProfileRepositoryMock = new Mock<IUserProfileRepository>();
//     }
//
//     [Fact]
//     public async Task Handle_WhenRequestIsValid_ReturnsUserProfileList()
//     {
//         // Arrange
//         var handler = new ListUserProfilesQueryHandler(_userProfileRepositoryMock.Object);
//         var query = new ListUserProfilesQuery();
//         var userProfiles = new List<UserProfileModel>()
//         {
//             new UserProfileModel()
//             {
//                 Age = 27,
//                 Gender = Gender.Female,
//                 Height = 150,
//                 Weight = 62
//             },
//             new UserProfileModel()
//             {
//                 Age = 27,
//                 Gender = Gender.Male,
//                 Height = 192,
//                 Weight = 90
//             },
//             new UserProfileModel()
//             {
//                 Age = 18,
//                 Gender = Gender.Female,
//                 Height = 192,
//                 Weight = 65
//             }
//         };
//
//         _userProfileRepositoryMock.Setup(
//             x => x.GetAllUserProfiles(It.IsAny<CancellationToken>()))
//             .ReturnsAsync(userProfiles);
//         
//
//         // Act
//         var result = await handler.Handle(query, default);
//
//         // Assert
//         Assert.Equal(userProfiles, result);
//     }
//
//     [Fact]
//     public async Task Handle_Should_ReturnNull_WhenNullUserProfiles()
//     {
//         // Arrange
//         var query = new ListUserProfilesQuery();
//         var handler = new ListUserProfilesQueryHandler(_userProfileRepositoryMock.Object);
//         List<UserProfileModel> userProfiles = null;
//
//         _userProfileRepositoryMock.Setup(
//                 x => x.GetAllUserProfiles(It.IsAny<CancellationToken>()))
//             .ReturnsAsync(userProfiles);
//         
//         // Act
//         var result = await handler.Handle(query, default);
//         
//         // Assert
//         Assert.Null(result);
//     }
// }