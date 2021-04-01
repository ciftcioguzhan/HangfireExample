using Hangfire.Api.JobManager;
using Hangfire.FireAndForget.Models;

namespace Hangfire.FireAndForget.FireAndForget
{
    public static class FireAndForgetJobs
    {
        /// <summary>
        /// Enqueue ; FireAndForget karşılık geliyor yani Bir kere ve hemen çalışan job tipidir. İş tanımlanır ve ardından bir kere tetiklenir.
        /// </summary>
        /// <param name="mailMessageDto"></param>
        public static void SendMailJob(MailMessageDto mailMessageDto)
        {
            Hangfire.BackgroundJob.Enqueue<EmailSendingJobManager>
                (job => job.Process(mailMessageDto));
        }
    }
}
