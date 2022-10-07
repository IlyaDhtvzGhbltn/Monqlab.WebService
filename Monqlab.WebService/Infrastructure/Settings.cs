using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Monqlab.WebService.Infrastructure
{
    public class Settings
    {
        /// <summary>
        /// Represents a key for getting Connection String from application configuration properties.
        /// </summary>
        public const string ConnectionString = "ConnectionStrings:DefaultConnection";
        /// <summary>
        /// Represents a key for getting Smtp Sender value from application configuration properties.
        /// </summary>
        public const string SmtpSender = "SmtpSettings:Sender";
        /// <summary>
        /// Represents a key for getting Smtp Host value from application configuration properties.
        /// </summary>
        public const string SmtpHost = "SmtpSettings:Host";
        /// <summary>
        /// Represents a key for getting Smtp Port value from application configuration properties.
        /// </summary>
        public const string SmtpPort = "SmtpSettings:Port";
    }
}
