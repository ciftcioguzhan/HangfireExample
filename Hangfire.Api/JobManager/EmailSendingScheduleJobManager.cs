using Hangfire.Api.Abstract;
using Hangfire.Api.Entities;
using System;
using System.Threading.Tasks;

namespace Hangfire.Api.JobManager
{
    public class EmailSendingScheduleJobManager
    {
        private readonly IMailService _mailService;

        public EmailSendingScheduleJobManager(IMailService mailService)
        {
            _mailService = mailService ?? throw new ArgumentNullException(nameof(mailService));
        }
        public bool Process(MailMessageDto mailMessageDto)
        {
          return  _mailService.SendMail(mailMessageDto);
        }
    }
}
