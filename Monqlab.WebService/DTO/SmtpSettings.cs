using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Monqlab.WebService.DTO
{
    public class SmtpSettings
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public string Sender { get; set; }

        public SmtpSettings(string host, int port, string sender)
        {
            Host = host;
            Port = port;
            Sender = sender;
        }
    }
}
