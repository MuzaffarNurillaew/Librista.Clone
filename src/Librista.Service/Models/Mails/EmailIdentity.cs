namespace Librista.Service.Models.Mails;

public class EmailIdentity(string email, string name)
{
    public required string Email { get; set; } = email;
    public required string Name { get; set; } = name;
}