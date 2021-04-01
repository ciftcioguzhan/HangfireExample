using Hangfire.Api.Entities;

namespace Hangfire.Api.Abstract
{
    public interface IMailService
    {
        bool SendMail(MailMessageDto mailMessageDto);
    }
}
