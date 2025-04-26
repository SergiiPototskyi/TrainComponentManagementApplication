using FluentValidation.Results;

namespace TCMApp.Server.Core;

public record Result<T>(T? Value = null, string Message = "") where T : class
{
    public bool Succeeded => Value is not null;

    public static Result<T> Success(T value)
    {
        return new Result<T>(value);
    }
    public static Result<T> Failure(List<ValidationFailure> failures)
    {
        return new Result<T>(null, string.Join(", ", failures.Select(x => x.ErrorMessage)));
    }

    public static Result<T> Failure(string message = "Failure")
    {
        return new Result<T>(null, message);
    }
}
public record Result(string? Value = null, string Message = "") : Result<string>(Value, Message)
{
    public static new Result Success => new(string.Empty);
    public static new Result Failure(string message = "Failure") => new(null, message);
}