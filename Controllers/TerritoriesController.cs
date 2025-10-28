using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NorthwindMVCEntity.Controllers
{
    public class TerritoriesController : Controller
    {
        private NorthwindEntities db = new NorthwindEntities();

        // GET: Territories
        public ActionResult Index()
        {
            return View(db.Territories.ToList());
        }

        // GET: Territories/Details/5
        public ActionResult Details(string id)
        {
            Territory ter = db.Territories.Find(id);
            return View(ter);
        }

        // GET: Territories/Create
        public ActionResult Create()
        {
            var re = db.Regions.Select(s => new { RegionID = s.RegionID, RegionDescription = s.RegionDescription }).ToList();
            ViewBag.RegionID = new SelectList(re, "RegionID", "RegionDescription");

            return View();
        }

        // POST: Territories/Create
        [HttpPost]
        public ActionResult Create(Territory obj)
        {
            var re = db.Regions.Select(s => new { RegionID = s.RegionID, RegionDescription = s.RegionDescription }).ToList();
            ViewBag.RegionID = new SelectList(re, "RegionID", "RegionDescription");


            try
            {
                // TODO: Add insert logic here
                if(ModelState.IsValid)
                {
                    db.Territories.Add(obj);
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

        // GET: Territories/Edit/5
        public ActionResult Edit(string id)
        {
            Territory obj = db.Territories.Find(id);

            var re = db.Regions.Select(s => new { RegionID = s.RegionID, RegionDescription = s.RegionDescription }).ToList();
            ViewBag.RegionID = new SelectList(re, "RegionID", "RegionDescription");

            return View(obj);
        }

        // POST: Territories/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, Territory obj)
        {
            var re = db.Regions.Select(s => new { RegionID = s.RegionID, RegionDescription = s.RegionDescription }).ToList();
            ViewBag.RegionID = new SelectList(re, "RegionID", "RegionDescription");

            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
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

        // GET: Territories/Delete/5
        public ActionResult Delete(string id)
        {
            Territory ter = db.Territories.Find(id);

            return View(ter);
        }

        // POST: Territories/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, Territory obj)
        {
            try
            {
                // TODO: Add delete logic here
                Territory ter = db.Territories.Find(id);
                db.Territories.Remove(ter);
                

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
