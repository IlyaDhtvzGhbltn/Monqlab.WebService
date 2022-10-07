using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Monqlab.WebService.Contracts.ToSendMessages
{
    public class ToSendMessagesRequest
    {
        /// <summary>
        /// Subject from POST request. Could not be Null or or empty or whitespace
        /// </summary>
        public string Subject { get; set; }
        /// <summary>
        /// Body from POST request
        /// </summary>
        public string Body { get; set; }
        /// <summary>
        /// Recipients Array in email format
        /// </summary>
        public string[] Recipients { get; set; }
    }
}
