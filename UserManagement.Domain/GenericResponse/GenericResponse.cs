namespace UserManagement.Domain.GenericResponse;

public class GenericResponse<T>
{
    public int StatusCode { get; private set; }
    public T? Payload { get; private set; }
    public string? Message { get; private set; }
    public bool Status { get; private set; }

    public static GenericResponse<T> Success(T? payload, string message, short statusCode)
        => new()
        {
            Payload = payload,
            Status = true,
            Message = message,
            StatusCode = statusCode
        };

    public static GenericResponse<T> Success(string message, short statusCode)
        => new()
        {
            Status = true,
            Message = message,
            StatusCode = statusCode
        };

    public static GenericResponse<T> Failure(T? payload, string message, short statusCode)
        => new()
        {
            Payload = payload,
            Status = false,
            Message = message,
            StatusCode = statusCode
        };

    public static GenericResponse<T> Failure(string message, short statusCode)
        => new()
        {
            Status = false,
            Message = message,
            StatusCode = statusCode
        };
}

public class GenericResponse
{
    public int StatusCode { get; private set; }
    public string? Message { get; private set; }
    public bool Status { get; private set; }

    public static GenericResponse Success(string message, short statusCode)
        => new()
        {
            Status = true,
            Message = message,
            StatusCode = statusCode
        };

    public static GenericResponse Failure(string message, short statusCode)
        => new()
        {
            Status = false,
            Message = message,
            StatusCode = statusCode
        };
}