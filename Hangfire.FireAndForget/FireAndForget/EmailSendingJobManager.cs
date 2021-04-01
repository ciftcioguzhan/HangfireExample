using Hangfire.FireAndForget.Models;
using Hangfire.FireAndForget.Service;
using System;

namespace Hangfire.Api.JobManager
{
    public class EmailSendingJobManager
    {
        private readonly IMailService _mailService;

        public EmailSendingJobManager(IMailService mailService)
        {
            _mailService = mailService ?? throw new ArgumentNullException(nameof(mailService));
        }
        public bool Process(MailMessageDto mailMessageDto)
        {
          return  _mailService.SendMail(mailMessageDto);
        }
    }
}
