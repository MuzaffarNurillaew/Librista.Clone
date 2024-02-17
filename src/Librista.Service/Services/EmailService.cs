using System.Text;
using Librista.Service.Interfaces;
using Librista.Service.Models.Mails;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;

namespace Librista.Service.Services;

public class EmailService(IOptions<EmailConfiguration> emailConfiguration) : IEmailService
{
    private EmailConfiguration _emailConfiguration = emailConfiguration.Value;

    public async Task SendAsync(Message message, CancellationToken cancellationToken)
    {
        // create email message
        var emailMessage = CreateEmailMessage(message);

        // send created message
        await SendAsync(emailMessage, cancellationToken);
    }

    private MimeMessage CreateEmailMessage(Message message)
    {
        var emailMessage = new MimeMessage();
        emailMessage.From.Add(new MailboxAddress(_emailConfiguration.NameOfFrom, _emailConfiguration.From));
        emailMessage.To.AddRange(message.To);
        emailMessage.Subject = message.Subject;

        var bodyBuilder = new BodyBuilder()
        {
            HtmlBody = message.Content
        };
        emailMessage.Body = bodyBuilder.ToMessageBody();
        
        return emailMessage;
    }

    private async Task SendAsync(MimeMessage message, CancellationToken cancellationToken)
    {
        using var client = new SmtpClient();
        try
        {
            var connectionTask = client.ConnectAsync(host: _emailConfiguration.SmtpServer,
                port: _emailConfiguration.Port,
                useSsl: true,
                cancellationToken: cancellationToken);
            var authenticationTask = client
                .AuthenticateAsync(userName: _emailConfiguration.Username,
                    password: _emailConfiguration.Password,
                    cancellationToken: cancellationToken);

            await connectionTask;
            await authenticationTask;

            await client.SendAsync(FormatOptions.Default, message, cancellationToken);
        }
        finally
        {
            await client.DisconnectAsync(true, cancellationToken);
        }
    }
}