using Application.Common.Interfaces;
using Application.DTOs;
using System.Net;
using System.Net.Mail;

namespace Shared.Services
{
    public class EmailService : IEmailService
    {
        public async Task SendAsync(EmailDTO request)
        {
            var emailClient = new SmtpClient("smtp.gmail.com");
            emailClient.EnableSsl = true;
            //utvj ggdz lvwb kilf
            // Get your Gmail username and password.
            var userName = "1994elmaty@gmail.com";
            var password = "felv maor vlck vjtd";

            // Create a NetworkCredential object.
            var networkCredential = new NetworkCredential(userName, password);

            // Set the credentials on the SmtpClient instance.
            emailClient.Credentials = networkCredential;

            var message = new MailMessage
            {
                From = new MailAddress(request.From),
                Subject = request.Subject,
                Body = request.Body
            };
            message.To.Add(new MailAddress(request.To));
            await emailClient.SendMailAsync(message);
        }
    }


}
