namespace Librista.Service.Models.Mails;

public class EmailIdentity
{
    public EmailIdentity(string email, string name)
    {
        Email = email;
        Name = name;
    }

    public EmailIdentity()
    {
        
    }
    public required string Email { get; set; }
    public required string Name { get; set; }
}