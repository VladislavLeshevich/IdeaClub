using MailKit.Net.Smtp;
using MimeKit;
using System.Threading.Tasks;

namespace IdeaClub.Services
{
    public class EmailConfirmationSender : IEmailSender
    {
        private const string SmtpServer = "smtp.gmail.com";
        private const int SmtpPortNumber = 587;
        private const string Email = "ideaClub12343@gmail.com";
        private const string Password = "cc7b35e1";

        public async Task SendEmailAsync(string email, string subject, string message)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("Adinistration", Email));
            emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message
            };

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync(SmtpServer, SmtpPortNumber, false);
                await client.AuthenticateAsync(Email, Password);
                await client.SendAsync(emailMessage);
                await client.DisconnectAsync(true);
            }
        }
    }
}