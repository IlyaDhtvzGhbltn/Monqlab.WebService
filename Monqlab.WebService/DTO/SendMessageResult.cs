using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Monqlab.WebService.DTO
{
    public class SendMessageResult
    {
        /// <summary>
        /// Email Address of the Recipient 
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// Could be Ok or Failed only
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// Exception when trying to send a message
        /// </summary>
        public string FailedMessage { get; set; }
        /// <summary>
        /// Date in UTC
        /// </summary>
        public DateTime CreationDateUtc { get; set; } = DateTime.UtcNow;


        public SendMessageResult()
        {

        }

        public SendMessageResult(string address)
        {
            Address = address;
        }

        public SendMessageResult(string address, string result)
            :this(address)
        {
            Status = result;
        }        
        
        public SendMessageResult(string address, string result, string failedMessage)
            :this(address, result)
        {
            FailedMessage = failedMessage;
        }
    }
}
