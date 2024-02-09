using Microsoft.AspNetCore.Http;

namespace Librista.Domain.Exceptions;

public class CustomException : Exception
{
    public int Code { get; set; } = StatusCodes.Status400BadRequest;

    public CustomException(int code)
    {
        Code = code;
    }

    public CustomException(int code, string message) : base(message)
    {
        Code = code;
    }

    public CustomException(string message) : base(message)
    { }
}