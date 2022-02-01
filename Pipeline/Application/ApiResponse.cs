namespace Application;

public class ApiResponse<T> where T : class
{
    public bool IsValid { get; private set; }

    public T? Data { get; private set; }

    public HttpStatusCode HttpStatusCode { get; private set; }

    public string ErrorMessage { get; private set; } = string.Empty;

    public static ApiResponse<T> Success(T data) => Success(data, HttpStatusCode.OK);

    public static ApiResponse<T> Success(T data, HttpStatusCode statusCode) =>
        new()
        {
            IsValid = true,
            Data = data,
            HttpStatusCode = statusCode
        };

    public static ApiResponse<T> Failure(string errorMessage, HttpStatusCode statusCode) =>
        new()
        {
            IsValid = false,
            HttpStatusCode = statusCode,
            ErrorMessage = errorMessage
        };
}
