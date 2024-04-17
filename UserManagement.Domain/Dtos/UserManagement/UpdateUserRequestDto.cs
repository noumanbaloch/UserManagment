namespace UserManagement.Domain.Dtos.UserManagement;
public sealed record UpdateUserRequestDto(int UserId,
    string FirstName,
    string LastName,
    string Email,
    string MobileNumber,
    DateTime DateOfBirth);