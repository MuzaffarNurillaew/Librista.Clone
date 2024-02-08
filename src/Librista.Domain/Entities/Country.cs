using Librista.Domain.Commons;

namespace Librista.Domain.Entities;

/// <inheritdoc cref="Auditable"/>
public class Country : Auditable
{
    public string Name { get; set; }
    public List<City> Cities { get; set; }
}