using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NorthwindMVCEntity.Controllers
{
    public class OrderDetailsController : Controller
    {
        private NorthwindEntities db = new NorthwindEntities();

        // GET: OrderDetails
        public ActionResult Index()
        {
            return View(db.Order_Details.ToList());
        }

        // GET: OrderDetails/Details/5
        public ActionResult Details(int orderId, int productId)
        {
            Order_Detail detail = db.Order_Details.Find(orderId, productId);
            return View(detail);
        }

        // GET: OrderDetails/Create
        public ActionResult Create()
        {
            var orders = db.Orders
                .Select(o => new {
                    OrderID = o.OrderID,
                    Info = "Order #" + o.OrderID + " - " + o.OrderDate
                }).ToList();
            ViewBag.OrderID = new SelectList(orders, "OrderID", "Info");

            var products = db.Products
                .Select(p => new {
                    ProductID = p.ProductID,
                    ProductInfo = p.ProductName + " (ID: " + p.ProductID + ")"
                }).ToList();
            ViewBag.ProductID = new SelectList(products, "ProductID", "ProductInfo");

            return View();
        }

        // POST: OrderDetails/Create
        [HttpPost]
        public ActionResult Create(Order_Detail detail)
        {
            var orders = db.Orders.Select(o => new {OrderID = o.OrderID,Info = "Order #" + o.OrderID + " - " + o.OrderDate}).ToList();
            ViewBag.OrderID = new SelectList(orders, "OrderID", "Info", detail.OrderID);

            var products = db.Products
                .Select(p => new {
                    ProductID = p.ProductID,
                    ProductInfo = p.ProductName + " (ID: " + p.ProductID + ")"
                }).ToList();
            ViewBag.ProductID = new SelectList(products, "ProductID", "ProductInfo", detail.ProductID);

            try
            {
                if (ModelState.IsValid)
                {
                    db.Order_Details.Add(detail);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(detail);
            }
            catch
            {
                return View(detail);
            }
        }

        // GET: OrderDetails/Edit/5
        public ActionResult Edit(int orderId, int productId)
        {
            Order_Detail detail = db.Order_Details.Find(orderId, productId);

            var orders = db.Orders
                .Select(o => new {
                    OrderID = o.OrderID,
                    Info = "Order #" + o.OrderID + " - " + o.OrderDate
                }).ToList();
            ViewBag.OrderID = new SelectList(orders, "OrderID", "Info", detail.OrderID);

            var products = db.Products
                .Select(p => new {
                    ProductID = p.ProductID,
                    ProductInfo = p.ProductName + " (ID: " + p.ProductID + ")"
                }).ToList();
            ViewBag.ProductID = new SelectList(products, "ProductID", "ProductInfo", detail.ProductID);

            return View(detail);
        }

        // POST: OrderDetails/Edit/5
        [HttpPost]
        public ActionResult Edit(int orderId, int productId, Order_Detail updated)
        {
            var orders = db.Orders
                .Select(o => new {
                    OrderID = o.OrderID,
                    Info = "Order #" + o.OrderID + " - " + o.OrderDate
                }).ToList();
            ViewBag.OrderID = new SelectList(orders, "OrderID", "Info", updated.OrderID);

            var products = db.Products
                .Select(p => new {
                    ProductID = p.ProductID,
                    ProductInfo = p.ProductName + " (ID: " + p.ProductID + ")"
                }).ToList();
            ViewBag.ProductID = new SelectList(products, "ProductID", "ProductInfo", updated.ProductID);

            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(updated).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(updated);
            }
            catch
            {
                return View(updated);
            }
        }

        // GET: OrderDetails/Delete/5
        public ActionResult Delete(int orderId, int productId)
        {
            Order_Detail detail = db.Order_Details.Find(orderId, productId);
            return View(detail);
        }

        // POST: OrderDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int orderId, int productId)
        {
            try
            {
                Order_Detail detail = db.Order_Details.Find(orderId, productId);
                db.Order_Details.Remove(detail);
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
