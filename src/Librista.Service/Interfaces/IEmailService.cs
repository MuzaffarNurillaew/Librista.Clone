using Librista.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Librista.Service.Interfaces;

public interface IEmailService: IEmailSender<User>
{ }