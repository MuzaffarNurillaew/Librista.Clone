using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Librista.Domain.Entities;

public class Role : IdentityRole<long>
{
    [MaxLength(20)]
    public override required string Name { get; set; }

    public List<User> Users { get; set; } = [];
}