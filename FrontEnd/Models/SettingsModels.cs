using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;


namespace FrontEnd.Models
{
    public class GoogleReCaptcha
    {
        public string ClientKey { get; set; }
        public string SecretKey { get; set; }
    }

    public class UserSettings
    {
        public bool RequireUniqueEmail { get; set; }
    }

    public class PasswordSettings
    {
        public int RequiredLength { get; set; }
        public bool RequireLowerCase { get; set; }
        public bool RequireUpperCase { get; set; }
        public bool RequireDigit { get; set; }
        public bool RequireNonAlphaNumeric { get; set; }
    }

    public class LockoutSettings
    {
        public bool AllowedForNewUsers { get; set; }
        public int DefaultLockoutTimeSpanInMins { get; set; }
        public int MaxFailedAccessAttempts { get; set; }
    }

    public class SMTPSettings
    {
        public string Host { get; set; }
        public string User { get; set; }
        public string Name {get;set;}
        public string Password { get; set; }
        public int Port { get; set; }
        public bool Flag { get; set; }
    }

    public class AppIdentitySettings
    {
        public UserSettings User { get; set; }
        public PasswordSettings Password { get; set; }
        public LockoutSettings Lockout { get; set; }
        //public SMTPSettings SMTPettings { get; set; }
        //public GoogleReCaptcha GoogleReCaptcha { get; set; }
    }
}
