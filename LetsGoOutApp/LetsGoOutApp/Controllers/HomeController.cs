﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LetsGoOutApp.Models;

namespace LetsGoOutApp.Controllers
{
    public class HomeController : Controller
    {
        private LetsGoOutAppContext db = new LetsGoOutAppContext();

        public ActionResult Index()
        {
            return View(db.Dogadjaji.Where(x => x.Datum > DateTime.Now).OrderBy(x => x.Datum).Take(3).ToList());
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}