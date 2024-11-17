namespace Shared.Errors;

/*public class Error
{
    public string Code { get; }
    public string Description { get; }
    public ErrorType Type { get; }

    private Error(string code, string description, ErrorType errorType)
    {
        this.Code = code;
        this.Description = description;
        this.Type = errorType;
    }

    public static Error NotFound(string code, string description) =>
        new Error(code, description, ErrorType.NotFound);
    
    public static Error Validation(string code, string description) =>
        new Error(code, description, ErrorType.Validation);
    
    public static Error Failure(string code, string description) =>
        new Error(code, description, ErrorType.Failure);
    
    public static Error Conflict(string code, string description) =>
        new Error(code, description, ErrorType.Conflict);
}
public enum ErrorType
{
    Failure = 0,
    Validation = 1, 
    NotFound = 2, 
    Conflict = 3 
}*/