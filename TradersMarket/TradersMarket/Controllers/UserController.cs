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
            if (allRegistered != null)
            {
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

                @ViewBag.StatusMessageDelete = "System Users";
                @ViewBag.RegisteredUsers = allUserModels;
                return View();
            }
            else
            {
                @ViewBag.StatusMessageDelete = "No Registered Users";
                return View();
            }
        }

        [HttpPost]
        public ActionResult ShowRegisteredUsersPost()
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

        public ActionResult UpdateUser(string username)
        {
            UpdateUserModel mod = new UpdateUserModel();
            User u = new UserBL().getUserByUsername(username);
            string townName = new UserBL().getTownName(u.TownID);
            List<Role> allRoles = new UserBL().getAllRoles();
            string roleName = new UserBL().getUserRole(username);


            List<Town> towns = new UserBL().getAllTowns();

            List<SelectListItem> townList = new List<SelectListItem>();
            List<SelectListItem> roleList = new List<SelectListItem>();

            foreach (Town t in towns)
            {
                if (t.TownID == u.TownID)
                {
                    townList.Add(new SelectListItem
                    {
                        Text = t.TownName,
                        Value = t.TownID.ToString(),
                        Selected = true
                    });
                }
                else
                {
                    townList.Add(new SelectListItem
                    {
                        Text = t.TownName,
                        Value = t.TownID.ToString(),
                    });
                }
            }

            foreach (Role r in allRoles)
            {
                if (r.RoleName == roleName)
                {

                    roleList.Add(new SelectListItem
                    {
                        Text = r.RoleName,
                        Value = r.RoleID.ToString(),
                        Selected = true
                    });
                }
                else
                {
                    roleList.Add(new SelectListItem
                    {
                        Text = r.RoleName,
                        Value = r.RoleID.ToString(),
                    });
                }
            }

            mod.username = u.Username;
            mod.password = u.Passwords;
            mod.name = u.Name;
            mod.surname = u.Surname;
            mod.email = u.Email;
            mod.mobileNumber = u.MobileNumber;

            mod.ListTowns = townList;
            mod.ListType = roleList;
            
            return View(mod);
        }

        [HttpPost]
        public ActionResult UpdateUser(UpdateUserModel mod)
        {
            User user = new User();
            user.Username = mod.username;
            user.Passwords = mod.password;
            user.Email = mod.email;
            user.MobileNumber = mod.mobileNumber;
            user.Name = mod.name;
            user.Surname = mod.surname;
            string userTown = Request.Form["TownDDL"];
            string userRole = Request.Form["TypeDDL"];
            user.TownID = Convert.ToInt32(userTown);


            Role r = new UserBL().getRoleByID(Convert.ToInt32(userRole));
            UserRole usr = new UserBL().getUsersUserRole(mod.username);
            usr.RoleID = Convert.ToInt32(userRole);

            new UserBL().UpdateUserRole(usr);
            new UserBL().UpdateUser(user);

            @ViewBag.SuccessMessage = "User Successfully Updated";
            return View("UpdateUserSuccessful");
        }
        
        public ActionResult DeleteUser(string username)
        {
            new UserBL().DeleteUser(username);
            @ViewBag.StatusMessageDelete = "User Successfully deleted";
            return View("ShowRegisteredUsersPost");
        }
    }
}
