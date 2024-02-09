using Librista.Service.Filters;

namespace Librista.Service.Interfaces.Filters;

public interface IPagable
{
    PaginationParameters? PaginationParameters { get; set; }
}