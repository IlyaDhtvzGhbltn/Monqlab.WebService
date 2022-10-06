﻿using Monqlab.WebService.Contracts.MessagesList;
using Monqlab.WebService.Contracts.ToSendMessages;
using Monqlab.WebService.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Monqlab.WebService.Infrastructure.Services
{
    public class MailService : IMailService
    {
        private readonly SmtpSettings _settings;

        public MailService(SmtpSettings settings)
        {
            _settings = settings;
        }

        public async Task<List<SendMessageResult>> SendMessageAsync(ToSendMessagesRequest request)
        {
            var results = new List<SendMessageResult>();
            var tasksToAwait = new List<Task>();

            foreach (string to in request.Recipients)
            {
                var emailClient = new SmtpClient(_settings.Host, _settings.Port);
                tasksToAwait.Add(TrySendMessageAsync(emailClient, _settings.Sender, request.Body, request.Subject, to));
            }
            await Task.WhenAll(tasksToAwait);
            foreach (var task in tasksToAwait)
            {
                SendMessageResult result = ((Task<SendMessageResult>)task).Result;
                results.Add(result);
            }

            return results;
        }

        public bool Validate(string[] recipients)
        {
            foreach (string address in recipients) 
            {
                try
                {
                    var addr = new MailAddress(address);
                }
                catch
                {
                    return false;
                }
            }
            return true;
        }

        private async Task<SendMessageResult> TrySendMessageAsync(SmtpClient smpt, string sender, string body, string subject, string to) 
        {
            MailMessage message = new MailMessage(sender, to);
            message.Subject = subject;
            message.Body = body;
            var result = new SendMessageResult(address: to);
            try 
            {
                await smpt.SendMailAsync(message);
                result.Status = "Ok";
            }
            catch (SmtpException smtpEx) 
            {
                result.FailedMessage = smtpEx.InnerException != null ? smtpEx.InnerException.Message : "SmtpException occured";
                result.Status = "Failed";
            }
            catch (Exception ex)
            {
                result.FailedMessage = ex.Message;
                result.Status = "Failed";
            }
            return result;
        }
    }
}
