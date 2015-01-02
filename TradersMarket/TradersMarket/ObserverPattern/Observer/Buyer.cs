using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Net;

namespace TradersMarket.ObserverPattern.Observer
{
    public class Buyer : ISubscribe
    {
        public string username { get; set; }
        public string email { get; set; }

        public void Notify()
        {
            //need to notify subscribers here
            //send email 
            //MailMessage mm = new MailMessage();
            //mm.To.Add(email);
            //mm.From = new MailAddress("noreplybuti@gmail.com");
            //mm.Subject = "New newsletter!";
            //mm.Body = "Dear " + username + ", a new newsletter was published ";
            //SmtpClient myclient = new SmtpClient("smtp.gmail.com", 587);
            //myclient.EnableSsl = true;
            //myclient.DeliveryMethod = SmtpDeliveryMethod.Network;
            //myclient.UseDefaultCredentials = false;
            //myclient.Credentials = new NetworkCredential("noreplybuti@gmail.com", "mcast4life");
            //myclient.Send(mm);


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