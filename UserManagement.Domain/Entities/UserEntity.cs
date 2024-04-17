namespace UserManagement.Domain.Entities;

public class UserEntity : BaseEntity
{
    public UserEntity(string firstName,
        string lastName,
        string email,
        string mobileNumber,
        DateTime dateOfBirth,
        string createdBy,
        DateTime createdOn,
        string? modifiedBy,
        DateTime? modifiedOn,
        bool deleted) :
        base(createdBy,
            createdOn,
            modifiedBy,
            modifiedOn,
            deleted)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        MobileNumber = mobileNumber;
        DateOfBirth = dateOfBirth;
        CreatedBy = createdBy;
        CreatedOn = createdOn;
        ModifiedBy = modifiedBy;
        ModifiedOn = modifiedOn;
        Deleted = deleted;
    }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public string MobileNumber { get; set; }

    public DateTime DateOfBirth { get; set; }
}