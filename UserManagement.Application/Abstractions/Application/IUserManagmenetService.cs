using UserManagement.Domain.Dtos.UserManagement;
using UserManagement.Domain.GenericResponse;

namespace UserManagement.Application.Abstractions.Application;
public interface IUserManagmenetService
{
    Task<GenericResponse<IEnumerable<GetUsersResponseDto>>> GetUsersAsync();

    Task<GenericResponse> AddUserAsync(AddUserRequestDto requestDto);

    Task<GenericResponse> UpdateUserAsync(UpdateUserRequestDto requestDto);

    Task<GenericResponse> DeleteUserAsync(DeleteUserRequestDto requestDto);


}