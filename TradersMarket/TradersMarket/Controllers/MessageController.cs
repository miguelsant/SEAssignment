﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TradersMarket.Controllers
{
    public class MessageController : Controller
    {
        //
        // GET: /Message/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult displaySuccessRegister()
        {
            return View();
        }

    }
}
