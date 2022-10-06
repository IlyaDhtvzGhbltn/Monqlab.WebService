using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Monqlab.WebService.Contracts.ToSendMessages
{
    public class ToSendMessagesRequest
    {
        public string Subject { get; set; }
        public string Body { get; set; }
        public string[] Recipients { get; set; }
    }
}
