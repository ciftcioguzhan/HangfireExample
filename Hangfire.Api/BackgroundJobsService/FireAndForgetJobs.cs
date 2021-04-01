using Hangfire.Api.Entities;
using Hangfire.Api.JobManager;

namespace Hangfire.Api.BackgroundJobsService
{
    public static class FireAndForgetJobs
    {
        public static void SendMailJob(MailMessageDto mailMessageDto)
        {
            Hangfire.BackgroundJob.Enqueue<EmailSendingScheduleJobManager>
                (job => job.Process(mailMessageDto));
        }
    }
}
