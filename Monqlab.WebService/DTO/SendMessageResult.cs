using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Monqlab.WebService.DTO
{
    public class SendMessageResult
    {
        public string Address { get; set; }
        public string Status { get; set; }
        public string FailedMessage { get; set; }
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
