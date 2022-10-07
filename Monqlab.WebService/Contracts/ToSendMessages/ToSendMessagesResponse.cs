using Monqlab.WebService.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Monqlab.WebService.Contracts.ToSendMessages
{
    public class ToSendMessagesResponse
    {
        /// <summary>
        /// Could not be Null or or empty or whitespace
        /// </summary>
        public string Subject { get; set; }
        /// <summary>
        /// Mail Statuses collection. An empty collection is created by default
        /// </summary>
        public List<MailStatus> MailStatuses { get; set; } = new List<MailStatus>();

        public ToSendMessagesResponse(string subject)
        {
            subject = Subject;
        }
    }

    public class MailStatus 
    {
        /// <summary>
        /// Email address
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// Could be Ok or Failed only
        /// </summary>
        public string Status { get; set; }

        public MailStatus(string address, string status)
        {
            Address = address;
            Status = status;
        }
    }
}
