using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Monqlab.WebService.Contracts.MessagesList
{
    public class MessagesListResponse
    {
        public List<SentMessage> SentMessages { get; set; } = new List<SentMessage>();
    }

    public class SentMessage
    {
        public Guid Id { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public DateTime Date { get; set; }
        public string Result { get; set; }
        public string FailedMessage { get; set; }
        public string Recipient { get; set; }
    }
}
