using Librista.Domain.Entities;
using Librista.Service.Interfaces;
using Librista.Service.Models.Mails;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using MimeKit;

namespace Librista.Service.Services;

public class EmailService(IOptions<EmailConfiguration> emailConfiguration)
    : IEmailSender<User>
{
    private EmailConfiguration _emailConfiguration = emailConfiguration.Value;
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

    private async Task SendAsync(MimeMessage message, CancellationToken cancellationToken = default)
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

    public async Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
        var to = new List<InternetAddress>();

        to.Add(new MailboxAddress(string.Empty, email));

        var message = new Message
        {
            To = to,
            Subject = subject,
            Content = htmlMessage
        };
        // create email message
        var emailMessage = CreateEmailMessage(message);

        // send created message
        await SendAsync(emailMessage);
    }

    public Task SendConfirmationLinkAsync(User user, string email, string confirmationLink)
    {
        throw new NotImplementedException();
    }

    public Task SendPasswordResetLinkAsync(User user, string email, string resetLink)
    {
        throw new NotImplementedException();
    }

    public Task SendPasswordResetCodeAsync(User user, string email, string resetCode)
    {
        throw new NotImplementedException();
    }
}