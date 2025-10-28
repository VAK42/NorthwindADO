using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NorthwindMVCEntity.Controllers
{
    public class CustomersController : Controller
    {
        private NorthwindEntities db = new NorthwindEntities();

        // GET: Customers
        public ActionResult Index()
        {
            return View(db.Customers.ToList());
        }

        [HttpPost]
        public ActionResult Index(FormCollection fr)
        {
            string searchText = fr["txtSearch"]?.ToString() ?? "";

            return View(db.Customers.Where(p => p.Address.Contains(searchText) || p.City.Contains(searchText) || p.Country.Contains(searchText) || p.CompanyName.Contains(searchText)).ToList());
        }

        // GET: Customers/Details/5
        public ActionResult Details(string id)
        {
            Customer customer = db.Customers.Find(id);
            return View(customer);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
           
            return View();
        }

        // POST: Customers/Create
        [HttpPost]
        public ActionResult Create(Customer obj)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid) 
                {
                    db.Customers.Add(obj);
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

        // GET: Customers/Edit/5
        public ActionResult Edit(string id)
        {
            Customer obj = db.Customers.Find(id);
            return View(obj);
        }

        // POST: Customers/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, Customer obj)
        {
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

        // GET: Customers/Delete/5
        public ActionResult Delete(string id)
        {
            Customer customer = db.Customers.Find(id);
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                Customer cus = db.Customers.Find(id);
                db.Customers.Remove(cus);
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
