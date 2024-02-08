using Librista.Domain.Commons;

namespace Librista.Domain.Entities;

/// <inheritdoc cref="Auditable"/>
public class City : Auditable
{
    public string Name { get; set; }
    public long CountryId { get; set; }
    public Country Country { get; set; }
}