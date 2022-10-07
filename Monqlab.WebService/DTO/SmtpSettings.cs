using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Monqlab.WebService.DTO
{
    public class SmtpSettings
    {
        /// <summary>
        /// Smtp Host from appsettings.json.
        /// </summary>
        public string Host { get; set; }
        /// <summary>
        /// Smtp Port from appsettings.json
        /// </summary>
        public int Port { get; set; }
        /// <summary>
        /// Mail Sender from appsettings.json
        /// </summary>
        public string Sender { get; set; }

        public SmtpSettings(string host, int port, string sender)
        {
            Host = host;
            Port = port;
            Sender = sender;
        }
    }
}
