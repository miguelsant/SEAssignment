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
        public void Notify()
        {
            //need to notify subscribers here
            //send email 
            //MailMessage mm = new MailMessage();
            //mm.To.Add(email);
            //mm.From = new MailAddress("noreplybuti@gmail.com");
            //mm.Subject = "New newsletter!";
            //mm.Body = "Dear " + username + ", a new newsletter was published ";
            //// mm.IsBodyHtml = true
            //SmtpClient myclient = new SmtpClient("smtp.gmail.com", 587);
            //myclient.EnableSsl = true;
            //myclient.DeliveryMethod = SmtpDeliveryMethod.Network;
            //myclient.UseDefaultCredentials = false;
            //myclient.Credentials = new NetworkCredential("noreplybuti@gmail.com", "mcast4life");
            //myclient.Send(mm);

        }
    }
}