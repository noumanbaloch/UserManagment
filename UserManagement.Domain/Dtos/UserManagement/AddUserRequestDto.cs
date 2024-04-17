namespace UserManagement.Domain.Dtos.UserManagement;
public sealed record AddUserRequestDto(string FirstName,
    string LastName,
    string Email,
    string MobileNumber,
    DateTime DateOfBirth);
