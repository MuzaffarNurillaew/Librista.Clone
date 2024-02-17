using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Librista.Domain.Commons;
using Microsoft.AspNetCore.Identity;

namespace Librista.Domain.Entities;

public class User : IdentityUser<long>, IAuditable
{
    [MinLength(3), MaxLength(20)]
    public override required string UserName { get; set; }
    public override required string Email { get; set; }
    
    [NotMapped]
    public required string Password { get; set; }
    public List<Role> Roles { get; set; } = [];
    [MaxLength(200)]
    public string? RefreshToken { get; set; }
    public DateTimeOffset CreatedDate { get; set; }
    public DateTimeOffset? UpdatedDate { get; set; }
    public DateTimeOffset? DeletedDate { get; set; }
    public bool IsDeleted { get; set; }
}