namespace Librista.Service.Models.Mails;

public class EmailConfiguration
{
    public required string From { get; set; }
    public required string NameOfFrom { get; set; }
    public required string SmtpServer { get; set; }
    public int Port { get; set; }
    public required string Username { get; set; }
    public required string Password { get; set; }
}