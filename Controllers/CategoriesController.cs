using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NorthwindMVCEntity.Controllers
{
    public class CategoriesController : Controller
    {
        private NorthwindEntities db = new NorthwindEntities();
        // GET: Categories
        public ActionResult Index()
        {
            return View(db.Categories.ToList());
        }

        // GET: Categories/Details/5
        public ActionResult Details(int id)
        {
            Category category = db.Categories.Find(id);
            return View(category);
        }

        // GET: Categories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        [HttpPost]
        public ActionResult Create(Category obj)
        {
            try
            {
                // TODO: Add insert logic here
                if(ModelState.IsValid)
                {
                    db.Categories.Add(obj);
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

        // GET: Categories/Edit/5
        public ActionResult Edit(int id)
        {
            Category obj = db.Categories.Find(id);
            return View(obj);
        }

        // POST: Categories/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Category obj)
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

        // GET: Categories/Delete/5
        public ActionResult Delete(int id)
        {
            Category cate = db.Categories.Find(id);
            return View(cate);
        }

        // POST: Categories/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Category obj)
        {
            try
            {
                // TODO: Add delete logic here
                obj = db.Categories.Find(id);
                db.Categories.Remove(obj);
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
