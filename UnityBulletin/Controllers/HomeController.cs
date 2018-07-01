using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UnityBulletin.Models;

namespace UnityBulletin.Controllers
{
    public class HomeController : Controller
    {
        public HomeModel model;

        // GET: Home
        public ActionResult Index()
        {
            model = new HomeModel();
            return View();
        }
    }
}