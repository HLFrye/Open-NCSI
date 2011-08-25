using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NCSIServ.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        //public ActionResult Index()
        //{
        //    ViewData["Message"] = "Welcome to ASP.NET MVC!";

        //    return View();
        //}

        public ActionResult Index(string id)
        {
            ViewData["Message"] = "Welcome to ASP.NET MVC!";

            return View();
        }

        public string Test(string username)
        {
            return "BLah blah "+username;
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
