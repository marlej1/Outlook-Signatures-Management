using Outlook_Signatures_Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace Outlook_Signatures_Management.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            List<Employee> employees;
            using (ApplicationDbContext context = new ApplicationDbContext())
            {

                employees = context.Employees.Include(e=>e.Department).ToList();

            }


            return View(employees);
        }

        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Employee/Create
        public ActionResult Create()
        {

            List<Department> departments;
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                 departments = context.Departments.ToList();
            }

            ViewBag.DeparmentList = new SelectList(departments, "DepartmentId", "DepartmentName");

            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(Employee model)
        {

            model.DateAdded = DateTime.Now;
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                try
                {
                    context.Employees.Add(model);
                   // context.SaveChanges();
                    // TODO: Add insert logic here

                    return RedirectToAction("Index");
                }
                catch(Exception ex)
                {
                    return Content(ex.Message);
                }
            } 

          
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Employee/Edit/5
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

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Employee/Delete/5
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
