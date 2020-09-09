using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontEnd.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message, string host, string port, string user, string pwd, string name, string ssl);
    }
}
