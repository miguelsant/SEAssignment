using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OrderingStates;
using TradersMarket.ObserverPattern.Subject;
using TradersMarket.ObserverPattern.Observer;
using Common;
using BusinessLayer;
namespace TradersMarket.Controllers
{
    public class OrderController : Controller
    {
        //
        // GET: /Order/

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult NewsletterPage()
        {

            return View();
        }

        public ActionResult SendAndNotify()
        {
            NewsLetter letter = new NewsLetter();

            EmailSubscriber emailSubscribers = new EmailSubscriber();

            List<User> subscribedUsers = new List<User>();

            subscribedUsers = new UserBL().getAllUsers();

            foreach (User u in subscribedUsers)
            {
                if (u.isSubscribed == false)
                {
                    subscribedUsers.Remove(u);
                }
                else
                {
                    emailSubscribers.userEmails.Add(u.Email);
                }
            }

            letter.Subscribe(emailSubscribers);
            letter.NotifySubscribers();
            

            //List<User> getUsers = new UserBL().getSubscribedUsers();

            //foreach(User u in getUsers)
            //{
            //    Buyer user = new Buyer();
            //    user.email = u.Email;
            //    user.username = u.Username;
            //    letter.Subscribe(user);
            //}

            //letter.NotifySubscribers();

            return RedirectToAction("Index","Home");
        }


        public ActionResult ManageOrderState()
        {
            OrderState ordState = new OrderState();
            ViewBag.registerMessage =  ordState.Register();
            ViewBag.ApproveMessage = ordState.Approve();
            ViewBag.dispatchMessage = ordState.Dispatch();
            return RedirectToAction("SubscribeUser","User");
        }

    }
}
