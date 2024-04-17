namespace UserManagement.Domain.Entities;

public class BaseEntity
{
    protected BaseEntity(
        string createdBy,
        DateTime createdOn,
        string? modifiedBy,
        DateTime? modifiedOn,
        bool deleted)
    {
        CreatedBy = createdBy;
        CreatedOn = createdOn;
        ModifiedBy = modifiedBy;
        ModifiedOn = modifiedOn;
        Deleted = deleted;
    }

    public int Id { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public bool Deleted { get; set; }
}