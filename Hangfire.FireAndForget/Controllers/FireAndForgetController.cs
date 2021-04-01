﻿using Microsoft.AspNetCore.Mvc;
using Hangfire.FireAndForget.FireAndForget;
using Hangfire.FireAndForget.Models;

namespace Hangfire.FireAndForget.Controllers
{
    public class FireAndForgetController : Controller
    {
        /// <summary>
        /// Mail Gönderme Arka Plan İş Akışını Başlatıyoruz.
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            for (int i = 0; i < 10; i++)
            {
                FireAndForgetJobs.SendMailJob(new MailMessageDto { Body = "Hangfire", From = "oguzhan.eksiii@gmail.com", Subject = "Hangfire Test", To = "oguzhan.eksiii@gmail.com" });
            }
            return Redirect("Hangfire");
        }
    }
}
