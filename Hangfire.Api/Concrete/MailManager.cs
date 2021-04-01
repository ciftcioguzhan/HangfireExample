using Hangfire.Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Hangfire.Api.Abstract;
using System.Net;

namespace Hangfire.Api.Concrete
{
    public class MailManager : IMailService
    {
        private readonly SmtpConfigDto _smtpConfigDto;


        public MailManager(IOptions<SmtpConfigDto> options)
        {
            _smtpConfigDto = options.Value;
        }


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

                    //SmtpServer.Port = 587;
                    SmtpServer.Credentials = new System.Net.NetworkCredential("oguzhan.eksiii@gmail.com", "Oguzhan.3455");
                    SmtpServer.EnableSsl = true;
                    //SmtpServer.UseDefaultCredentials = false;

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

        public Task SendUserRegisterMailAsync(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
