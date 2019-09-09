using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TrashCollector.Models;

namespace TrashCollector.Controllers
{
    public class EmployeesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private object employee;

        // GET: Employees
        public ActionResult Index()
        {
            return View(db.Employees.ToList());
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }
        public ActionResult PickUpToday(string SearchText)
        {

            var today = DateTime.Today;
            var pickuptoday = today.DayOfWeek.ToString();
            var userLoggedin = User.Identity.GetUserId();
            var employee = db.Employees.Where(e => e.ApplicationUserId == userLoggedin).Single();
            
            
            
            if(SearchText == null)
            {
                var customersInArea = db.Customers.Where(c => c.zipCode == employee.zipCode && c.dayOfTheWeekForPickUp == pickuptoday).ToList();
                return View(customersInArea);
            }

            else
            {
                var customersByDay = db.Customers.Where(c => c.zipCode == employee.zipCode && c.dayOfTheWeekForPickUp == SearchText).ToList();
                return View(customersByDay);

            }
            
        }
        
        public ActionResult ConfirmPickUp(int Id)
        {

            // grab correct customer based off of customer id passed in as parameter
            // set customer pick up bool to true
            //save in database
            //redirect to pickuptoday page
            
            var customer = db.Customers.Find(Id);
            customer.gotPickedUp = true;
            ChargingCustomer(customer);

            db.SaveChanges();
            return RedirectToAction("PickUpToday");

        }


        public void ChargingCustomer(Customer customer)
        {
            customer.amountOwed += 5.00;
            //employee picked up then charged that customer
            //if customers trash is picked up then customer amount owed is increased

        }



        


        // GET: Employees/Create
        public ActionResult Create()
        {
            Employee employee = new Employee();
            return View(employee);
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,firstName,lastName,zipCode,ApplicationUserId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                employee.ApplicationUserId = User.Identity.GetUserId();
                db.Employees.Add(employee);
                db.SaveChanges();
                //pickupstoday 
                return RedirectToAction("");
            }

            return View(employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,firstName,lastName,zipCode,ApplicationUserId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                employee.firstName = Request.Form["firstName"];
                employee.lastName = Request.Form["lastName"];
                employee.zipCode = Request.Form["zipCode"];
                db.SaveChanges();
                return RedirectToAction("Index","Employees");
            }
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index","Employee");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
