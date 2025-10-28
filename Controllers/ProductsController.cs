using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NorthwindMVCEntity.Controllers
{
    public class ProductsController : Controller
    {
        private NorthwindEntities db = new NorthwindEntities();

        // GET: Products
        public ActionResult Index()
        {
            return View(db.Products.ToList());
        }

        [HttpPost]
        public ActionResult Index(FormCollection fr)
        {
            string searchText = fr["txtSearch"]?.ToString() ?? "";

            return View(db.Products.Where(p => p.ProductName.Contains(searchText) || p.UnitsInStock.ToString().Contains(searchText) || p.QuantityPerUnit.ToString().Contains(searchText)).ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(int id)
        {
            Product product = db.Products.Find(id);
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            var sup = db.Suppliers.Select(s => new {SupplierID = s.SupplierID, CompanyName = s.CompanyName}).ToList();
            var cate = db.Categories.Select(s => new { CategoryID = s.CategoryID, CategoryName = s.CategoryName }).ToList();

            ViewBag.SupplierID = new SelectList(sup,"SupplierID", "CompanyName");
            ViewBag.CategoryID = new SelectList(cate,"CategoryID", "CategoryName");

            return View();
        }

        // POST: Products/Create
        [HttpPost]
        public ActionResult Create(Product obj)
        {
            var sup = db.Suppliers.Select(s => new { SupplierID = s.SupplierID, CompanyName = s.CompanyName }).ToList();
            var cate = db.Categories.Select(s => new { CategoryID = s.CategoryID, CategoryName = s.CategoryName }).ToList();

            ViewBag.SupplierID = new SelectList(sup, "SupplierID", "CompanyName");
            ViewBag.CategoryID = new SelectList(cate, "CategoryID", "CategoryName");

            try
            {
                // TODO: Add insert logic here
                if(ModelState.IsValid)
                {
                    db.Products.Add(obj);
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

        // GET: Products/Edit/5
        public ActionResult Edit(int id)
        {
            Product product = db.Products.Find(id);

            var sup = db.Suppliers.Select(s => new { SupplierID = s.SupplierID, CompanyName = s.CompanyName }).ToList();
            var cate = db.Categories.Select(s => new { CategoryID = s.CategoryID, CategoryName = s.CategoryName }).ToList();

            ViewBag.SupplierID = new SelectList(sup, "SupplierID", "CompanyName");
            ViewBag.CategoryID = new SelectList(cate, "CategoryID", "CategoryName");

            return View(product);
        }

        // POST: Products/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Product obj)
        {
            var sup = db.Suppliers.Select(s => new { SupplierID = s.SupplierID, CompanyName = s.CompanyName }).ToList();
            var cate = db.Categories.Select(s => new { CategoryID = s.CategoryID, CategoryName = s.CategoryName }).ToList();

            ViewBag.SupplierID = new SelectList(sup, "SupplierID", "CompanyName");
            ViewBag.CategoryID = new SelectList(cate, "CategoryID", "CategoryName");

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

        // GET: Products/Delete/5
        public ActionResult Delete(int id)
        {
            Product p = db.Products.Find(id);

            return View(p);
        }

        // POST: Products/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                Product product = db.Products.Find(id);
                db.Products.Remove(product);
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
