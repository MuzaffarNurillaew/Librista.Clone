namespace Librista.Domain.Exceptions;

public class NotFoundException : Exception
{
    public const int Code = 404;

    public NotFoundException(string message)
        : base(message)
    { }
    public NotFoundException()
        : base(message: "Entity is not found.")
    { }
    public NotFoundException(Type type)
        : base(message: $"{type.Name} is not found.")
    { }
    public NotFoundException(Type type, long id)
        : base(message: $"{type.Name} is not found with ID={id}")
    { }
}