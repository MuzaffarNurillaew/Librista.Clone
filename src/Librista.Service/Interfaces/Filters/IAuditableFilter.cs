namespace Librista.Service.Interfaces.Filters;

public interface IAuditableFilter
{
    DateTimeOffset? MinimumCreationDate { get; set; }
    DateTimeOffset? MaximumCreationDate { get; set; }
    
}