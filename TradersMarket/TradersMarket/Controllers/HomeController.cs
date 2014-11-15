using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer;
using Common;
using TradersMarket.Models;

namespace TradersMarket.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult LoginUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginUser(LoginUserModel mod)
        {
            Enum loginValue = new UserBL().loginUser(mod.username, mod.password);

            if (loginValue.ToString() == "ValidCredentials")
            {
                Session["Username"] = mod.username;
                Session["LoggedIn"] = true;
                //need to 
                return View();
            }
            else if (loginValue.ToString() == "InvalidCredentials")
            {
                @ViewBag.LoggingInStatus = "Invalid Credentials";
            }

            return View();
        }

        public ActionResult RegisterNewUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegisterNewUser(RegisterUserModel mod)
        {
            UserBL usbl = new UserBL();
            Enum registerstatus = usbl.addUser(mod.username, mod.password, mod.email, mod.name, mod.surname, mod.mobileNumber, mod.TownID,mod.RoleID);

            if (registerstatus.ToString() == "UsernameExists")
            {
                @ViewBag.DisplayRegisterStatus = "Username already exists, please select another one";
                return View();
            }
            else if (registerstatus.ToString() == "EmailExists")
            {
                @ViewBag.DisplayRegisterStatus = "Email already exists, please select another one";
                return View();
            }
            else
            {
                @ViewBag.DisplayRegisterStatus = "Registration Successful";
                return View();
            }
            //@ViewBag.SuccessMessage = "Registration Successfull";
            //return RedirectToAction("displaySuccessRegister", "displaySuccessRegister", "Message");
            
        }


        public ActionResult About()
        {
            return View();
        }
    }
}
