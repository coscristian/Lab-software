//using Shared.Errors;

namespace Shared.Results;

public class Result<T>
{
    public bool IsFailure { get; set; }
    public bool IsSuccess { get; set; }
    public T? Data { get; set; }
}