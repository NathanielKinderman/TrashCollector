using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrashCollector.Models;

namespace TrashCollector.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext applicationDbContext;
        public HomeController()
        {
            applicationDbContext = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            // if customer, go to customer deatils
            if (User.IsInRole("Customer"))
            {
                var userId = User.Identity.GetUserId();
                var customerList = applicationDbContext.Customers.Where(x => x.ApplicationUserId == userId).ToList();
                if (!customerList.Any())
                {
                    throw new Exception("Customer does not exist");
                }
                return RedirectToAction("Edit", "Customers", new { id = customerList.First().Id});
            }
            // else if employee, go somewhere else
            else if (User.IsInRole("Employee"))
            {
                return RedirectToAction("PickUpToday", "Employees");
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