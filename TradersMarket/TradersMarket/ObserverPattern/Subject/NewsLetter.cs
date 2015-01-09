using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TradersMarket.ObserverPattern.Observer;
using System.Net.Mail;

namespace TradersMarket.ObserverPattern.Subject
{
    public class NewsLetter
    {
        private IList<ISubscribe> subscribedUsers = new List<ISubscribe>();
        

        public void Subscribe(ISubscribe observer)
        {
            subscribedUsers.Add(observer);
        }

        public void Unsubscribe(ISubscribe observer)
        {
            subscribedUsers.Remove(observer);

        }

        public void NotifySubscribers()
        {
            foreach (ISubscribe s in subscribedUsers)
            {
                s.Notify();
            }
        }

    }
}