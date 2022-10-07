using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Monqlab.WebService.Contracts.MessagesList
{
    public class MessagesListResponse
    {
        /// <summary>
        /// Message Details Collection. An empty collection is created by default
        /// </summary>
        public List<SentMessage> SentMessages { get; set; } = new List<SentMessage>();
    }

    public class SentMessage
    {
        /// <summary>
        /// Entry Id from Database in GUID format
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Entry Subject from Database
        /// </summary>
        public string Subject { get; set; }
        /// <summary>
        /// Entry Body from Database
        /// </summary>
        public string Body { get; set; }
        /// <summary>
        /// Date in UTC
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// Entry Result from Database. Could be Ok or Failed only
        /// </summary
        public string Result { get; set; }
        /// <summary>
        /// Exception when trying to send a message or NULL
        /// </summary>
        public string FailedMessage { get; set; }
        /// <summary>
        /// Email Address of the Recipient 
        /// </summary>
        public string Recipient { get; set; }
    }
}
