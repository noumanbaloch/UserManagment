using UserManagement.Domain.Dtos.UserManagement;
using UserManagement.Domain.Entities;

namespace UserManagement.Application.Abstractions.Infrastructure;
public interface IUserManagementRepository
{
    Task AddUserAsync(UserEntity user);

    Task UpdateUserAsync(UserEntity user);

    Task<IEnumerable<GetUsersResponseDto>> GetUsersAsync();

    Task<bool> CheckIfUserExistAsync(int UserId);

    Task<UserEntity?> GetUserByIdAsync(int UserId);
}