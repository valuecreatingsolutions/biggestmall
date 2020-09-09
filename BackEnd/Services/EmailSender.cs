using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Net.Http;
using BackEnd.Models;
using System.IO;
using Newtonsoft.Json;

namespace BackEnd.Services
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string message, string host, string port, string user, string pwd, string name, string ssl)
        {
            MailMessage mailMsg = new MailMessage();

            mailMsg.From = new MailAddress(user, name);
            mailMsg.To.Add(new MailAddress(email));

            mailMsg.Subject = subject;
            mailMsg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(message, null, MediaTypeNames.Text.Plain));
            mailMsg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(message, null, MediaTypeNames.Text.Html));

            SmtpClient smtpClient = new SmtpClient(host, Convert.ToInt32(port));
            smtpClient.EnableSsl = Convert.ToBoolean(ssl);
            smtpClient.Timeout = 0;
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.UseDefaultCredentials = true;
            smtpClient.Credentials = new NetworkCredential(user, pwd);

            smtpClient.Send(mailMsg);
            return Task.CompletedTask;
        }
    }
}
