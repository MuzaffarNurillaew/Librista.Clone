using Librista.Service.Models.Mails;

namespace Librista.Service.Interfaces;

public interface IEmailService
{
    Task SendAsync(Message message, CancellationToken cancellationToken);
}