﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NorthwindMVCEntity.Controllers
{
    public class RegionController : Controller
    {
        private NorthwindEntities db = new NorthwindEntities();

        // GET: Region
        public ActionResult Index()
        {
            return View(db.Regions.ToList());
        }

        // GET: Region/Details/5
        public ActionResult Details(int id)
        {
            Region region = db.Regions.Find(id);

            return View(region);
        }

        // GET: Region/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Region/Create
        [HttpPost]
        public ActionResult Create(Region obj)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                { 
                    db.Regions.Add(obj);
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

        // GET: Region/Edit/5
        public ActionResult Edit(int id)
        {
            Region region = db.Regions.Find(id);
            return View(region);
        }

        // POST: Region/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Region obj)
        {
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

        // GET: Region/Delete/5
        public ActionResult Delete(int id)
        {
            Region region = db.Regions.Find(id);
            return View(region);
        }

        // POST: Region/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                Region region = db.Regions.Find(id);
                db.Regions.Remove(region);
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
