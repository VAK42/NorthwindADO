using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NorthwindMVCEntity.Controllers
{
    public class OrdersController : Controller
    {
        private NorthwindEntities db = new NorthwindEntities();
        // GET: Orders
        public ActionResult Index()
        {
            return View(db.Orders.ToList());
        }

        [HttpPost]
        public ActionResult Index(FormCollection fr)
        {
            string searchText = fr["txtSearch"]?.ToString() ?? "";

            return View(db.Products.Where(p => p.ProductName.Contains(searchText)).ToList());
        }

        // GET: Orders/Details/5
        public ActionResult Details(int id)
        {
            Order order = db.Orders.Find(id);

            return View(order);
        }

        // GET: Orders/Create
        public ActionResult Create()
        {
            var cus = db.Customers.Select(s => new { CustomerID = s.CustomerID, CompanyName = s.CompanyName }).ToList();
            var emp = db.Employees.Select(s => new { EmployeeID = s.EmployeeID, FullName = s.FirstName + " " + s.LastName }).ToList();
            var ship = db.Shippers.Select(s => new { ShipperID = s.ShipperID, CompanyName = s.CompanyName}).ToList();

            ViewBag.CustomerID = new SelectList(cus, "CustomerID", "CompanyName");
            ViewBag.EmployeeID = new SelectList(emp, "EmployeeID", "FullName");
            ViewBag.ShipVia = new SelectList(ship, "ShipperID", "CompanyName");

            return View();
        }

        // POST: Orders/Create
        [HttpPost]
        public ActionResult Create(Order obj)
        {
            var cus = db.Customers.Select(s => new { CustomerID = s.CustomerID, CompanyName = s.CompanyName }).ToList();
            var emp = db.Employees.Select(s => new { EmployeeID = s.EmployeeID, FullName = s.FirstName + " " + s.LastName }).ToList();
            var ship = db.Shippers.Select(s => new { ShipperID = s.ShipperID, CompanyName = s.CompanyName }).ToList();

            ViewBag.CustomerID = new SelectList(cus, "CustomerID", "CompanyName");
            ViewBag.EmployeeID = new SelectList(emp, "EmployeeID", "FullName");
            ViewBag.ShipVia = new SelectList(ship, "ShipperID", "CompanyName");

            try
            {
                // TODO: Add insert logic here
                if(ModelState.IsValid)
                {
                    db.Orders.Add(obj);
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                return View(obj);
            }
            catch
            {
                return View(obj);
            }
        }

        // GET: Orders/Edit/5
        public ActionResult Edit(int id)
        {
            Order o = db.Orders.Find(id);

            var cus = db.Customers.Select(s => new { CustomerID = s.CustomerID, CompanyName = s.CompanyName }).ToList();
            var emp = db.Employees.Select(s => new { EmployeeID = s.EmployeeID, FullName = s.FirstName + " " + s.LastName }).ToList();
            var ship = db.Shippers.Select(s => new { ShipperID = s.ShipperID, CompanyName = s.CompanyName }).ToList();

            ViewBag.CustomerID = new SelectList(cus, "CustomerID", "CompanyName");
            ViewBag.EmployeeID = new SelectList(emp, "EmployeeID", "FullName");
            ViewBag.ShipVia = new SelectList(ship, "ShipperID", "CompanyName");

            return View(o);
        }

        // POST: Orders/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Order obj)
        {
            var cus = db.Customers.Select(s => new { CustomerID = s.CustomerID, CompanyName = s.CompanyName }).ToList();
            var emp = db.Employees.Select(s => new { EmployeeID = s.EmployeeID, FullName = s.FirstName + " " + s.LastName }).ToList();
            var ship = db.Shippers.Select(s => new { ShipperID = s.ShipperID, CompanyName = s.CompanyName }).ToList();

            ViewBag.CustomerID = new SelectList(cus, "CustomerID", "CompanyName");
            ViewBag.EmployeeID = new SelectList(emp, "EmployeeID", "FullName");
            ViewBag.ShipVia = new SelectList(ship, "ShipperID", "CompanyName");

            try
            {
                // TODO: Add update logic here
                if(ModelState.IsValid)
                {
                    db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                return View(obj);
            }
            catch
            {
                return View(obj);
            }
        }

        // GET: Orders/Delete/5
        public ActionResult Delete(int id)
        {
            Order o = db.Orders.Find(id);
            return View(o);
        }

        // POST: Orders/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                Order order = db.Orders.Find(id);
                db.Orders.Remove(order);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
