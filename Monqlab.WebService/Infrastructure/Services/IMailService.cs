using Monqlab.WebService.Contracts.MessagesList;
using Monqlab.WebService.Contracts.ToSendMessages;
using Monqlab.WebService.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Monqlab.WebService.Infrastructure.Services
{
    public interface IMailService
    {
        Task<List<SendMessageResult>> SendMessageAsync(ToSendMessagesRequest message);
        bool Validate(string[] recipients);
    }
}