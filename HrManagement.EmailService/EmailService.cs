using System.Net;
using System.Net.Mail;

namespace HrManagement.EmailService
{
    public class EmailService : IEmailService
    {
        private readonly string _sender;
        private readonly string _password;
        private readonly string _host;
        private readonly int _port;

        public EmailService(string sender, string password, string host, int port)
        {
            _sender = sender;
            _password = password;
            _host = host;
            _port = port;
        }

        public void SendEmail(string recipeint, string subject, string body)
        {
            var mail = new MailMessage(_sender, recipeint, subject, body)
            {
                IsBodyHtml = true
            };

            var smtp = new SmtpClient(_host, _port)
            {
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(_sender, _password),
                EnableSsl = true
            };
            smtp.Send(mail);    
        }
    }
}
