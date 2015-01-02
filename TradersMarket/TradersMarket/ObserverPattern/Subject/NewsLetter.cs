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
        

        public void Subscribe(ISubscribe buyer)
        {
            subscribedUsers.Add(buyer);
        }

        public void Unsubscribe(ISubscribe buyer)
        {
            subscribedUsers.Remove(buyer);
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