using Hangfire.FireAndForget.Models;
using System;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Hangfire.FireAndForget.Service
{
    public class MailService : IMailService
    {

        public bool SendMail(MailMessageDto mailMessageDtol)
        {

            bool control = true;
            try
            {
                MailMessage mail = new MailMessage();
                using (SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com",587))
                {
                    mail.From = new MailAddress(mailMessageDtol.From);
                    mail.To.Add(mailMessageDtol.To);
                    mail.Subject = mailMessageDtol.Subject;
                    mail.Body = mailMessageDtol.Body;

                    SmtpServer.Credentials = new System.Net.NetworkCredential("mail adresiniz", "şifreniz");
                    SmtpServer.EnableSsl = true;

                    SmtpServer.Send(mail);
                }
            }

            catch (Exception ex)
            {
                control = false;
                throw new Exception(ex.Message);
            }

            return control;
        }
    }
}
