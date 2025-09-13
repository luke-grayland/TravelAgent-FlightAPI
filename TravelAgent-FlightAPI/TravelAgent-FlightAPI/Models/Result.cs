namespace TravelAgent_FlightAPI.Models;

public class Result<T>
{
    private Result() {}
    
    public bool IsSuccess { get; private set; }
    public string? ErrorMessage { get; private set; }
    public T? Data { get; private set; }

    public static Result<T> Success(T data)
    {
        return new Result<T>()
        {
            IsSuccess = true,
            ErrorMessage = null,
            Data = data
        };
    }

    public static Result<T> Failure(string errorMessage)
    {
        return new Result<T>()
        {
            IsSuccess = false,
            ErrorMessage = errorMessage
        };
    }
}