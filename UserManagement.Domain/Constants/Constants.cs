namespace UserManagement.Domain.Constants;

public struct ApiStatusCodes
{
    // 100 series for failures
    public const int USER_DOES_NOT_EXIST = 100;
    public const int NO_RECORD_FOUND = 101;

    // 200 series for success
    public const int USER_UPDATED_SUCCESSFULLY = 200;
    public const int USER_ADDED_SUCCESSFULLY = 201;
    public const int RECORD_FOUNDED_SUCCESSFULLY = 202;
    public const int USER_DELETED_SUCCESSFULLY = 203;
}

public struct ApiResponseMessages
{
    public const string SOMETHING_WENT_WRONG = "Something went wrong.";
    public const string USER_DOES_NOT_EXIST = "User does not exist.";
    public const string USER_UPDATED_SUCCESSFULLY = "User updated successfully.";
    public const string USER_ADDED_SUCCESSFULLY = "User added successfully.";
    public const string RECORD_FOUNDED_SUCCESSFULLY = "Record founded successfully.";
    public const string USER_DELETED_SUCCESSFULLY = "User deleted successfully.";
    public const string NO_RECORD_FOUND = "No record found.";
}

public struct Usernames
{
    public const string SYSTEM_USERNAME = "UserManagementFramework";
}