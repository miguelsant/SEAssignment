using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Net;

namespace TradersMarket.ObserverPattern.Observer
{
    public class EmailSubscriber : ISubscribe
    {
       public List<string> userEmails = new List<string>();




       public void Notify()
       {
           foreach (string email in userEmails)
           {
               using (MailMessage mail = new MailMessage())
               {
                   mail.From = new MailAddress("noreplybuti@gmail.com");
                   mail.To.Add(email);
                   mail.Subject = "Newsletter has been published!";
                   mail.Body = "Our new news letter for this month has been published,please check it out";
                   mail.IsBodyHtml = true;
                   using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                   {
                       smtp.Credentials = new NetworkCredential("noreplybuti@gmail.com", "mcast4life");
                       smtp.EnableSsl = true;
                       smtp.Send(mail);
                   }
               }
           }
       }
    }
}