using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common;
using BusinessLayer;
using TradersMarket.Models;

namespace TradersMarket.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/

        public ActionResult ShowRegisteredUsers()
        {

            List<User> allRegistered = new UserBL().getAllUsers();
            List<UserModel> allUserModels = new List<UserModel>();
            string town;
            foreach (User u in allRegistered)
            {
                UserModel model = new UserModel();
                model.Username = u.Username;
                model.Password = u.Passwords;
                model.Name = u.Name;
                model.Mobile = u.MobileNumber;
                model.Email = u.Email;
                model.TownID = u.TownID;
                model.Surname = u.Surname;
                model.TownName = new UserBL().getTownName(u.TownID);
                allUserModels.Add(model);
                
            }


            @ViewBag.RegisteredUsers = allUserModels;
            return View();
        }



        
        public ActionResult DeleteUser(string username)
        {
            new UserBL().DeleteUser(username);
            return View("ShowRegisteredUsers");
        }
    }
}
