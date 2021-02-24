using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace GithubJobsEnterpriseProject.Services
{
    public class EmailSenderService : IEmailSenderService
    {
        private string _email;
        private MailMessage SetMail()
        {
            var mailMessage = new MailMessage
            {
                From = new MailAddress("githubjobsapi@gmail.com"),
                Subject = "Successful registration!",
                Body = "<h1>Hello</h1><br>" +
                "<p>You recieved this email because your registration was successful to the <strong>GithubJobs page</strong>!</p>" +
                "<p>Enjoy your time while browsing on the website!</p>" +
                "<p>Best regards,</p>" +
                "<p><i>The GithubJobs team</i></p>",
                IsBodyHtml = true,
            };
            mailMessage.To.Add(_email);
            return mailMessage;
        }

        public void SendEmail(string registeredEmail)
        {
            _email = registeredEmail;
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("githubjobsapi@gmail.com", "Githubapi01"),
                EnableSsl = true,
            };
            MailMessage message = SetMail();
            smtpClient.Send(message);


        }
    }
}
