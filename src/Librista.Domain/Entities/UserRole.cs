using Microsoft.AspNetCore.Identity;

namespace Librista.Domain.Entities;

public class UserRole : IdentityUserRole<long>
{
    public required User User { get; set; }
    public required Role Role { get; set; }
}