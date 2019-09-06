using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TrashCollector.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            // if customer, go to customer deatils
            if (User.IsInRole("Customer"))
            {
                return RedirectToAction("Edit", "Customer");
            }
            // else if employee, go somewhere else
            else if (User.IsInRole("Employee"))
            {
                return RedirectToAction("Edit", "Employee");
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}