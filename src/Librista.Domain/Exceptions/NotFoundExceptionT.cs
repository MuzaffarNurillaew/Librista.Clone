namespace Librista.Domain.Exceptions;

public class NotFoundException<T> : NotFoundException
{
    public NotFoundException(long id)
        : base(typeof(T), id)
    { }

    public NotFoundException()
        : base(typeof(T))
    { }
}