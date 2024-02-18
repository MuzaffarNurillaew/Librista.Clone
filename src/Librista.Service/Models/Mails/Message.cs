using MimeKit;

namespace Librista.Service.Models.Mails;

public class Message
{
    public Message(List<EmailIdentity> to, string subject, string content)
    {
        To = new();
        To.AddRange(to.Select(email => new MailboxAddress(email.Name, email.Email)));
        Subject = subject;
        Content = content;
    }

    public Message()
    { }

    public required List<InternetAddress> To { get; set; }
    public required string Subject { get; set; }
    public required string Content { get; set; }
}