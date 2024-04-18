using UserManagement.Application.Abstractions.Application;
using UserManagement.Application.Abstractions.Infrastructure;
using UserManagement.Application.Mapping;
using UserManagement.Domain.Constants;
using UserManagement.Domain.Dtos.UserManagement;
using UserManagement.Domain.GenericResponse;

namespace UserManagement.Application.Services;
public class UserManagementService : IUserManagmenetService
{
    private readonly IUserManagementRepository _userManagementRepository;

    public UserManagementService(IUserManagementRepository userManagementRepository)
    {
        _userManagementRepository = userManagementRepository;
    }

    public async Task<GenericResponse> AddUserAsync(AddUserRequestDto requestDto)
    {
        await _userManagementRepository.AddUserAsync(requestDto.Map());

        return GenericResponse.Success(ApiResponseMessages.USER_ADDED_SUCCESSFULLY, ApiStatusCodes.USER_ADDED_SUCCESSFULLY);
    }

    public async Task<GenericResponse> DeleteUserAsync(DeleteUserRequestDto requestDto)
    {
        if(!await _userManagementRepository.CheckIfUserExistAsync(requestDto.UserId))
        {
            return GenericResponse.Failure(ApiResponseMessages.USER_DOES_NOT_EXIST, ApiStatusCodes.USER_DOES_NOT_EXIST);
        }

        var user = await _userManagementRepository.GetUserByIdAsync(requestDto.UserId);

        user!.Deleted = true;
        user.ModifiedOn = DateTime.UtcNow;

        await _userManagementRepository.UpdateUserAsync(user);

        return GenericResponse.Success(ApiResponseMessages.USER_DELETED_SUCCESSFULLY, ApiStatusCodes.USER_DELETED_SUCCESSFULLY);
    }

    public async Task<GenericResponse<IEnumerable<GetUsersResponseDto>>> GetUsersAsync()
    {
        var users = await _userManagementRepository.GetUsersAsync();

        if(users is null || !users.Any())
        {
            return GenericResponse<IEnumerable<GetUsersResponseDto>>.Failure(ApiResponseMessages.NO_RECORD_FOUND, ApiStatusCodes.NO_RECORD_FOUND);
        }

        return GenericResponse<IEnumerable<GetUsersResponseDto>>.Success(users, ApiResponseMessages.RECORD_FOUNDED_SUCCESSFULLY, ApiStatusCodes.RECORD_FOUNDED_SUCCESSFULLY);
    }

    public async Task<GenericResponse> UpdateUserAsync(UpdateUserRequestDto requestDto)
    {
        var user = await _userManagementRepository.GetUserByIdAsync(requestDto.UserId);

        if (user == null)
        {
            return GenericResponse.Failure(ApiResponseMessages.USER_DOES_NOT_EXIST, ApiStatusCodes.USER_DOES_NOT_EXIST);
        }

        user = requestDto.Map(user);

        await _userManagementRepository.UpdateUserAsync(user);

        return GenericResponse.Success(ApiResponseMessages.USER_UPDATED_SUCCESSFULLY, ApiStatusCodes.USER_UPDATED_SUCCESSFULLY);
    }
}
