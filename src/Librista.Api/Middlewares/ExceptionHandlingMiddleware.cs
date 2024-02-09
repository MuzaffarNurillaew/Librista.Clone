using Librista.Domain.Exceptions;

namespace Librista.Api.Middlewares;

public class ExceptionHandlingMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await next.Invoke(httpContext);
        }
        catch (NotFoundException exception)
        {
            await HandleExceptionAsync(httpContext, exception, NotFoundException.Code);
        }
        catch (ValidationException exception)
        {
            await HandleValidationExceptionAsync(httpContext, exception);
        }
        catch (CustomException exception)
        {
            await HandleExceptionAsync(httpContext, exception, exception.Code);
        }
        catch (Exception exception)
        {
            await HandleExceptionAsync(httpContext, exception, 500);
        }
    }
    

    private async Task HandleExceptionAsync(HttpContext context, Exception ex, int code)
    {
        context.Response.StatusCode = code;
        await context.Response.WriteAsJsonAsync(new
        {
            Code = code,
            Message = ex.Message
        });
    }
    private static async Task HandleValidationExceptionAsync(HttpContext context, ValidationException exception)
    {
        context.Response.StatusCode = StatusCodes.Status400BadRequest;
        await context.Response.WriteAsJsonAsync(new
        {
            Code = StatusCodes.Status400BadRequest,
            Message = "Validation failed",
            Errors = exception.Errors.Select(error => new
            {
                error.PropertyName,
                error.ErrorMessage,
            }).Distinct()
        });
    }
}