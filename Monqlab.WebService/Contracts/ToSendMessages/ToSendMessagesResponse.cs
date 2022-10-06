using Monqlab.WebService.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Monqlab.WebService.Contracts.ToSendMessages
{
    public class ToSendMessagesResponse
    {
        public string Subject { get; set; }
        public List<MailStatus> MailStatuses { get; set; } = new List<MailStatus>();

        public ToSendMessagesResponse(string subject)
        {
            subject = Subject;
        }
    }

    public class MailStatus 
    {
        public string Address { get; set; }
        public string Status { get; set; }

        public MailStatus(string address, string status)
        {
            Address = address;
            Status = status;
        }
    }
}
