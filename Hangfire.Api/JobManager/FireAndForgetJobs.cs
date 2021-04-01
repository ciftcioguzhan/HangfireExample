using Hangfire.Api.Entities;
using System;

namespace Hangfire.Api.JobManager
{
    public static class FireAndForgetJobs
    {
        //public static void SendMailRegisterJobs(int userId)
        //{
        //    Hangfire.BackgroundJob.Schedule<EmailSendingScheduleJobManager>
        //         (
        //          job => job.Process(new Entities.MailMessageDto { Body = "test", From = "oguzhan", Subject = "selam", To = "aa" }),
        //          TimeSpan.FromSeconds(10)
        //          );
        //}

        public static void SendMailJob(MailMessageDto mailMessageDto)
        {
            Hangfire.BackgroundJob.Enqueue<EmailSendingScheduleJobManager>
                (
                 job => job.Process(mailMessageDto)
                 );
        }
    }
}
