using Hangfire.FireAndForget.Models;

namespace Hangfire.FireAndForget.Service
{
    public interface IMailService
    {
        bool SendMail(MailMessageDto mailMessageDto);
    }
}
