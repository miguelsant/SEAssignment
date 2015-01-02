using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OrderingStates;
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
