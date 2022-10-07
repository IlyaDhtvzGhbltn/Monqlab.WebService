using Monqlab.WebService.Contracts.MessagesList;
using Monqlab.WebService.Contracts.ToSendMessages;
using Monqlab.WebService.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Monqlab.WebService.Infrastructure.Services
{
    public interface IMailService
    {
        /// <summary>
        /// Sends email messages to all recipients
        /// </summary>
        /// <param name="message">ToSendMessagesRequest</param>
        /// <returns>A task with a collection of the results of sending messages. If the message was not sent, it contains the error text</returns>
        Task<List<SendMessageResult>> SendMessageAsync(ToSendMessagesRequest message);

        /// <summary>
        /// Checks the address format of all recipients
        /// </summary>
        /// <param name="recipients"></param>
        /// <returns>If the address format is correct returns true. If any of the recipients contains an invalid format false.</returns>
        bool Validate(string[] recipients);
    }
}