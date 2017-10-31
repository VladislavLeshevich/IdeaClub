using MailKit.Net.Smtp;
using MimeKit;
using System.Threading.Tasks;

namespace IdeaClub.Services
{
    public class EmailService
    {
        private const string _smtpServer = "smtp.gmail.com";
        private const int _smtpPortNumber = 587;
        private const string _email = "ideaClub12343@gmail.com";
        private const string _password = "cc7b35e1";


        public async Task SendEmailAsync(string email, string subject, string message)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("Adinistration", _email));
            emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message
            };

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync(_smtpServer, _smtpPortNumber, false);
                await client.AuthenticateAsync(_email, _password);
                await client.SendAsync(emailMessage);
                await client.DisconnectAsync(true);
            }
        }
    }
}