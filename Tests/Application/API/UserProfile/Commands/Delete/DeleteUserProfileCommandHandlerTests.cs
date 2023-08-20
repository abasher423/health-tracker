// using Application.API.V1.UserProfile.Commands.Delete;
// using Application.API.V1.UserProfile;
// using Moq;
//
// namespace Tests.Application.API.UserProfile.Commands.Delete;
//
// public class DeleteUserProfileCommandHandlerTests
// {
//     private readonly Mock<IUserProfileRepository> _userProfileRepository;
//
//     public DeleteUserProfileCommandHandlerTests()
//     {
//         _userProfileRepository = new Mock<IUserProfileRepository>();
//     }
//
//     [Fact]
//     public async Task Handle_Should_ThrowArgumentNullException_WhenNullRequest()
//     {
//         // Arrange
//         var handler = new DeleteUserProfileCommandHandler(_userProfileRepository.Object);
//         
//         // Act and Assert
//         await Assert.ThrowsAsync<ArgumentNullException>(async () =>
//         {
//             await handler.Handle(null, default);
//         });
//     }
//
//     [Fact]
//     public async Task Handle_Should_ThrowArgumentNullException_WhenEmptyRequestId()
//     {
//         // Arrange
//         var id = Guid.Empty;
//         var command = new DeleteUserProfileCommand(id);
//         var handler = new DeleteUserProfileCommandHandler(_userProfileRepository.Object);
//         
//         // Act and Assert
//         await Assert.ThrowsAsync<ArgumentNullException>(async () =>
//         {
//             await handler.Handle(command, default);
//         });
//     }
//
//     [Fact]
//     public async Task Handle_Should_ReturnTrue_WhenUserProfileDeleted()
//     {
//         // Arrange
//         var id = Guid.NewGuid();
//         var command = new DeleteUserProfileCommand(id);
//         var handler = new DeleteUserProfileCommandHandler(_userProfileRepository.Object);
//
//         _userProfileRepository.Setup(
//                 x => x.DeleteUserProfile(id, It.IsAny<CancellationToken>()))
//             .ReturnsAsync(true);
//         
//         // Act
//         var result = await handler.Handle(command, default);
//         
//         // Assert
//         Assert.True(result);
//     }
//
//     [Fact]
//     public async Task Handle_Should_ReturnFalse_WhenUserProfileIsNotDeleted()
//     {
//         // Arrange
//         var command = new DeleteUserProfileCommand(Guid.NewGuid());
//         var handler = new DeleteUserProfileCommandHandler(_userProfileRepository.Object);
//
//         _userProfileRepository.Setup(
//             x => x.DeleteUserProfile(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
//             .ReturnsAsync(false);
//         
//         // Act
//         var result = await handler.Handle(command, default);
//         
//         // Assert
//         Assert.False(result);
//     }
// }