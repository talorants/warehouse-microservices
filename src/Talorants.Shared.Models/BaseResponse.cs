namespace Talorants.Shared.Model;

public class BaseResponse
{
    public bool IsSuccess { get; set; }
    public string? ErrorMessage { get; set; }
    
    public BaseResponse(bool isSuccess) => IsSuccess = isSuccess;
    public BaseResponse(string? errorMessage) => ErrorMessage = errorMessage;

    public BaseResponse(bool isSuccess, string? errorMessage)
    {   
        IsSuccess = isSuccess;
        ErrorMessage = errorMessage;
    }
}

public class BaseResponse<T> : BaseResponse
{
    public T? Data { get; set; }
    public BaseResponse(bool isSuccess) : base(isSuccess) { }
    public BaseResponse(string? errorMessage) : base(errorMessage) { }
    public BaseResponse(bool isSuccess, string? errorMessage) : base(isSuccess, errorMessage) { }
}