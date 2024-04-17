using UserManagement.Domain.Constants;
using UserManagement.Domain.Dtos.UserManagement;
using UserManagement.Domain.Entities;

namespace UserManagement.Application.Mapping;

public static class DtoToEntityMappingExtensions
{
    public static UserEntity Map(this AddUserRequestDto requestDto)
    {
        return new UserEntity(requestDto.FirstName,
            requestDto.LastName,
            requestDto.Email,
            requestDto.MobileNumber,
            requestDto.DateOfBirth,
            Usernames.SYSTEM_USERNAME,
            DateTime.UtcNow,
            null,
            null,
            false);
    }

    public static UserEntity Map(this UpdateUserRequestDto requestDto, UserEntity user)
    {
        user.FirstName = requestDto.FirstName;
        user.LastName = requestDto.LastName;
        user.Email = requestDto.Email;
        user.DateOfBirth = requestDto.DateOfBirth;
        user.ModifiedBy = requestDto.Email;
        user.ModifiedOn = DateTime.UtcNow;

        return user;
    }
}