using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Monqlab.WebService.Infrastructure
{
    public class Settings
    {
        public const string ConnectionString = "ConnectionStrings:DefaultConnection";
        public const string SmtpSender = "SmtpSettings:Sender";
        public const string SmtpHost = "SmtpSettings:Host";
        public const string SmtpPort = "SmtpSettings:Port";
    }
}
