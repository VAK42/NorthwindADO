using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NorthwindMVCEntity.Controllers
{
    public class UsersController : Controller
    {
        private NorthwindEntities db = new NorthwindEntities();
        // GET: Users
        public ActionResult Index()
        {
            return View(db.USERS.ToList());
        }

        // GET: Users/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Users/Create
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(USER obj)
        {
            var users = db.USERS.Where(a => a.UserName == obj.UserName && a.Password == obj.Password);
            if (users.Count() > 0)
            {
                if (users.FirstOrDefault().Remember)
                {
                    Response.Cookies["UserName"].Value = users.FirstOrDefault().UserName;
                    Response.Cookies["UserName"].Expires = DateTime.MaxValue;
                }
                Session["UserName"] = users.FirstOrDefault().UserName;

                return RedirectToAction("Index", "Home");
            }
            return View(obj);
        }


        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Users/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Users/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
