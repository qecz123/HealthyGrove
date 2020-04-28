using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HealthyGrove.Models;

namespace HealthyGrove.Controllers
{
    public class HomeController : Controller
    {
        private HealthyGrove_ModelContainer db = new HealthyGrove_ModelContainer();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult AboutPlants()
        {
            ViewBag.Message = "Your About The Plant page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult FAQ()
        {
            ViewBag.Message = "Your FAQ page.";

            return View();
        }

        public ActionResult Links()
        {
            ViewBag.Message = "Your Link page.";

            return View();
        }

        public ActionResult FindNursery()
        {
            ViewBag.Message = "Your FindNursery page.";

            return View();
        }
    }
}