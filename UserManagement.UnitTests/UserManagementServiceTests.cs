using Moq;
using UserManagement.Application.Abstractions.Infrastructure;
using UserManagement.Application.Services;
using UserManagement.Domain.Constants;
using UserManagement.Domain.Dtos.UserManagement;
using UserManagement.Domain.Entities;

namespace UserManagement.UnitTests;

[TestFixture]
public class UserManagementServiceTests
{
    private Mock<IUserManagementRepository> _mockRepository;
    private UserManagementService _userService;

    [SetUp]
    public void Setup()
    {
        _mockRepository = new Mock<IUserManagementRepository>();
        _userService = new UserManagementService(_mockRepository.Object);
    }

    [Test]
    public async Task AddUserAsync_ValidInput_ReturnsSuccess()
    {
        // Arrange
        var requestDto = new AddUserRequestDto("Muhammad", "Nouman", "muhammadnouman@gmail.com", "03017672234", DateTime.Today.AddYears(-27));

        // Act
        var result = await _userService.AddUserAsync(requestDto);

        // Assert
        Assert.IsTrue(result.Status);
        Assert.That(result.Message, Is.EqualTo(ApiResponseMessages.USER_ADDED_SUCCESSFULLY));
        Assert.That(result.StatusCode, Is.EqualTo(ApiStatusCodes.USER_ADDED_SUCCESSFULLY));
    }

    [Test]
    public async Task DeleteUserAsync_UserExists_ReturnsSuccess()
    {
        // Arrange
        var userId = 1;
        _mockRepository.Setup(repo => repo.CheckIfUserExistAsync(userId)).ReturnsAsync(true);
        _mockRepository.Setup(repo => repo.GetUserByIdAsync(userId)).ReturnsAsync(new UserEntity("Muhammad", "Nouman", "noumanbaloch@gmail.com", "03002334345", DateTime.Today.AddMonths(-20), "System", DateTime.Now, null, null, false));

        var requestDto = new DeleteUserRequestDto(userId);

        // Act
        var result = await _userService.DeleteUserAsync(requestDto);

        // Assert
        Assert.IsTrue(result.Status);
        Assert.That(result.Message, Is.EqualTo(ApiResponseMessages.USER_DELETED_SUCCESSFULLY));
        Assert.That(result.StatusCode, Is.EqualTo(ApiStatusCodes.USER_DELETED_SUCCESSFULLY));
    }

    [Test]
    public async Task GetUsersAsync_ReturnsUsers_IfFound()
    {
        // Arrange
        var users = new List<GetUsersResponseDto> { new(1, "Muhammad", "Nouman", "noumanbaloch@gmail.com", "03001235432", DateTime.Now) };
        _mockRepository.Setup(repo => repo.GetUsersAsync()).ReturnsAsync(users);

        // Act
        var result = await _userService.GetUsersAsync();

        // Assert
        Assert.IsTrue(result.Status);
        Assert.That(result.Message, Is.EqualTo(ApiResponseMessages.RECORD_FOUNDED_SUCCESSFULLY));
        Assert.That(result.StatusCode, Is.EqualTo(ApiStatusCodes.RECORD_FOUNDED_SUCCESSFULLY));
        Assert.NotNull(result.Payload);
    }

    [Test]
    public async Task UpdateUserAsync_UserExists_ReturnsSuccess()
    {
        // Arrange
        var userId = 1;
        var user = new UserEntity("Muhammad", "Nouman", "noumanbaloch@gmail.com", "03002334345", DateTime.Today.AddMonths(-20), "System", DateTime.Now, null, null, false);
        _mockRepository.Setup(repo => repo.GetUserByIdAsync(userId)).ReturnsAsync(user);

        var requestDto = new UpdateUserRequestDto(userId, "Muhammad", "Nouman", "noumanbaloch@gmail.com", "03330022343", DateTime.Now);

        // Act
        var result = await _userService.UpdateUserAsync(requestDto);

        // Assert
        Assert.IsTrue(result.Status);
        Assert.That(result.Message, Is.EqualTo(ApiResponseMessages.USER_UPDATED_SUCCESSFULLY));
        Assert.That(result.StatusCode, Is.EqualTo(ApiStatusCodes.USER_UPDATED_SUCCESSFULLY));
    }

}
