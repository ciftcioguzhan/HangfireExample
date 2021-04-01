using System.Net.Mail;

namespace Hangfire.FireAndForget.Models
{
    public class MailMessageDto
    {
        public string To { get; set; }
        public string From { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

        public MailMessage GetMailMessage()
        {
            var mailMessage = new MailMessage
            {
                Subject = this.Subject,
                Body = this.Body,
                From = new MailAddress(this.From)
            };
            mailMessage.To.Add(To);
            return mailMessage;
        }
    }
}
