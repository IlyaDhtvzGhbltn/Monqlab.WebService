using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Monqlab.WebService.Contracts.MessagesList;
using Monqlab.WebService.Contracts.ToSendMessages;
using Monqlab.WebService.DTO;
using Monqlab.WebService.Entities;
using Monqlab.WebService.Infrastructure;
using Monqlab.WebService.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Monqlab.WebService.Controllers.Api
{
    [Route("api")]
    [AllowAnonymous]
    [ApiController]
    public class MailsController : ControllerBase
    {

        private readonly IMailService _mailService;
        private readonly IFactory<MonqlabDbContext> _contextFactory;

        public MailsController(IMailService mailService, IFactory<MonqlabDbContext> contextFactory)
        {
            _mailService = mailService;
            _contextFactory = contextFactory;
        }

        [HttpPost("mails")]
        public async Task<ToSendMessagesResponse> SendMessages([FromBody] ToSendMessagesRequest request) 
        {
            if(string.IsNullOrWhiteSpace(request.Subject))
            {
                throw new EmptySubjectException("Subject cannot be empty");
            }

            bool valid = _mailService.Validate(request.Recipients);
            if (valid)
            {
                ToSendMessagesResponse resp = new ToSendMessagesResponse(request.Subject);
                List<SendMessageResult> sendingResults = await _mailService.SendMessageAsync(request);
                using (var context = _contextFactory.Create()) 
                {
                    foreach (SendMessageResult result in sendingResults)
                    {
                        resp.MailStatuses.Add(new MailStatus(result.Address, result.Status));
                        resp.Subject = request.Subject;
                        context.SentMessages.Add(new Entities.SentMessage()
                        {
                            Body = request.Body,
                            CreationDateUtc = result.CreationDateUtc,
                            FailedMessage = result.FailedMessage,
                            Subject = request.Subject,
                            Result = result.Status,
                            Recipient = result.Address
                        });
                    }
                    await context.SaveChangesAsync();
                }
                return resp;
            }
            else throw new InvalidEmailException("One or many recipients addresses invalid");
        }

        [HttpGet("mails")]
        public async Task<MessagesListResponse> GetSentMessages() 
        {
            var resp = new MessagesListResponse();
            using (var context = _contextFactory.Create())
            {
                var messages = await context.SentMessages.ToListAsync();
                messages.ForEach((m) => 
                {
                    resp.SentMessages.Add(new Contracts.MessagesList.SentMessage()
                    {
                        Body = m.Body, 
                        Date = m.CreationDateUtc, 
                        FailedMessage = m.FailedMessage, 
                        Id = m.Id, 
                        Recipient = m.Recipient, 
                        Result = m.Result, 
                        Subject = m.Subject
                    });
                });
            }
            return resp;
        }
    }
}
