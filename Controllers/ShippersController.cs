using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NorthwindMVCEntity.Controllers
{
    public class ShippersController : Controller
    {
        private NorthwindEntities db = new NorthwindEntities();
        // GET: Shippers
        public ActionResult Index()
        {
            return View(db.Shippers.ToList());
        }

        [HttpPost]
        public ActionResult Index(FormCollection fr)
        {
            string searchText = fr["txtSearch"]?.ToString() ?? "";

            return View(db.Shippers.Where(p => p.CompanyName.Contains(searchText) || p.Phone.Contains(searchText)).ToList());
        }

        // GET: Shippers/Details/5
        public ActionResult Details(int id)
        {
            Shipper shipper = db.Shippers.Find(id);
            return View(shipper);
        }

        // GET: Shippers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Shippers/Create
        [HttpPost]
        public ActionResult Create(Shipper obj)
        {
            try
            {
                // TODO: Add insert logic here
                if(ModelState.IsValid)
                {
                    db.Shippers.Add(obj);
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

        // GET: Shippers/Edit/5
        public ActionResult Edit(int id)
        {
            Shipper obj = db.Shippers.Find(id);
            return View(obj);
        }

        // POST: Shippers/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Shipper obj)
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

        // GET: Shippers/Delete/5
        public ActionResult Delete(int id)
        {
            Shipper shipper  = db.Shippers.Find(id);
            return View(shipper);
        }

        // POST: Shippers/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Shipper obj)
        {
            try
            {
                // TODO: Add delete logic here
                obj = db.Shippers.Find(id);
                db.Shippers.Remove(obj);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View(obj);
            }
        }
    }
}
