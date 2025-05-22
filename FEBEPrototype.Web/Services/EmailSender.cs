using FEBEPrototype.Web.Models;
using Microsoft.AspNetCore.Identity.UI.Services;
using NETCore.MailKit.Core;
using System.Threading.Tasks;

namespace FEBEPrototype.Web.Services
{
    public class EmailSender: IEmailSender
    {
        private readonly IEmailService _emailService;

        public EmailSender(IEmailService emailService)
        {
            _emailService = emailService;
        }

        public Task SendEmailAsync(string email, string subject, string message)
        {
            return _emailService.SendAsync("test@test.com", "Email", message);
        }

    }
}
