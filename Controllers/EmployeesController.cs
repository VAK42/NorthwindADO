﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NorthwindMVCEntity.Controllers
{
    public class EmployeesController : Controller
    {
        private NorthwindEntities db = new NorthwindEntities();

        // GET: Employees
        public ActionResult Index()
        {

            return View(db.Employees.ToList());
        }
        [HttpPost]
        public ActionResult Index(FormCollection fr)
        {
            string searchText = fr["txtSearch"]?.ToString() ?? "";

            return View(db.Employees.Where(p => p.FirstName.Contains(searchText) || p.LastName.Contains(searchText) || p.Address.Contains(searchText)).ToList());
        }


        // GET: Employees/Details/5
        public ActionResult Details(int id)
        {
            Employee employee = db.Employees.Find(id);
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            //ViewBag.ReportsTo = new SelectList(db.Employees,"EmployeeID","FirstName");

            var emp = db.Employees.Select(s=> new {EmployeeID = s.EmployeeID, FullName = s.FirstName + " " + s.LastName}).ToList();
            ViewBag.ReportsTo = new SelectList(emp, "EmployeeID", "FullName");

            return View();
        }

        // POST: Employees/Create
        [HttpPost]
        public ActionResult Create(Employee obj)
        {
            var emp = db.Employees.Select(s => new { EmployeeID = s.EmployeeID, FullName = s.FirstName + " " + s.LastName }).ToList();
            ViewBag.ReportsTo = new SelectList(emp, "EmployeeID", "FullName",obj.ReportsTo);
            try
            {
                // TODO: Add insert logic here

                if (ModelState.IsValid) 
                {
                    db.Employees.Add(obj);
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

        // GET: Employees/Edit/5
        public ActionResult Edit(int id)
        {
            Employee employee = db.Employees.Find(id);

            var emp = db.Employees.Select(s => new { EmployeeID = s.EmployeeID, FullName = s.FirstName + " " + s.LastName }).ToList();
            ViewBag.ReportsTo = new SelectList(emp, "EmployeeID", "FullName", employee.ReportsTo);

            return View(employee);
        }

        // POST: Employees/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Employee obj)
        {
            var emp = db.Employees.Select(s => new { EmployeeID = s.EmployeeID, FullName = s.FirstName + " " + s.LastName }).ToList();
            ViewBag.ReportsTo = new SelectList(emp, "EmployeeID", "FullName", obj.ReportsTo);


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

        // GET: Employees/Delete/5
        public ActionResult Delete(int id)
        {
            Employee employee = db.Employees.Find(id);

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Employee obj)
        {
            try
            {
                // TODO: Add delete logic here
                Employee emp = db.Employees.Find(id);
                db.Employees.Remove(emp);
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
