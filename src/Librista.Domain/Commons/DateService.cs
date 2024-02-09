namespace Librista.Domain.Commons;

public static class DateService
{
    public static DateTimeOffset Now()
    {
        return DateTimeOffset.UtcNow;
    }
}