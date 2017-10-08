using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeaClub.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
