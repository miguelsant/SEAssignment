using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer;
using Common;
namespace TradersMarket.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<User> allTheUsers = new UserBL().getAllUsers();
            string name = allTheUsers[0].Username;

            ViewBag.Message = name;

            return View();
        }



        public ActionResult About()
        {
            return View();
        }
    }
}
