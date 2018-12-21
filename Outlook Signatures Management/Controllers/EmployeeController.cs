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
        [ChildActionOnly]
        public ActionResult Index()
        {
            List<Employee> employees;
            using (ApplicationDbContext context = new ApplicationDbContext())
            {

                employees = context.Employees.Include(e=>e.Department).ToList();

            }
            return PartialView("_EmployeeList", employees);
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
            List<Signature> signatures;
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                 departments = context.Departments.ToList();
                signatures = context.Signatures.ToList();
               
            }

            ViewBag.DeparmentList = new SelectList(departments, "DepartmentId", "DepartmentName");
            ViewBag.SignatureList = new SelectList(signatures, "SignatureId", "SignatureName");

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
                    if (model.DefaultSignatureId != null)
                    {
                        model.HasIndividualDefaultSignature = true;
                    }
                    if (model.ForwardReplySignatureId != null)
                    {
                        model.HasIndividualForwardReplySignature = true;
                    }

                    context.Employees.Add(model);
                   context.SaveChanges();
                    // TODO: Add insert logic here
                    
                    return Json(model);
                }
                catch(Exception ex)
                {
                    return Content(ex.Message);
                }
            } 

          
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int employeeId)
        {
            List<Department> departments;
            List<Signature> signatures;


            Employee empl;

            using (ApplicationDbContext context = new ApplicationDbContext())
            {
            

                try
                {
                    empl = context.Employees.Find(employeeId);
                    departments = context.Departments.ToList();
                    signatures = context.Signatures.ToList();

                    ViewBag.DeparmentList = new SelectList(departments, "DepartmentId", "DepartmentName");
                    ViewBag.SignatureList = new SelectList(signatures, "SignatureId", "SignatureName");

                    if (empl != null)
                    {
                        return PartialView("_Edit", empl);
                    }
                    else
                    {
                        return RedirectToAction("Create");
                    }
                }
                catch (Exception)
                {

                    throw;
                }
                

            }
         
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(Employee model)
        {

            Employee emp;
            List<Department> departments;

            try
            {
            
                using (ApplicationDbContext context = new ApplicationDbContext())
                {
                    emp = context.Employees.Find(model.EmployeeId);
                    departments = context.Departments.ToList();
                    ViewBag.DeparmentList = new SelectList(departments, "DepartmentId", "DepartmentName");


                    if (emp != null)
                    {
                        if (model.DefaultSignatureId != null && model.DefaultSignatureId != emp.DefaultSignatureId)
                        {
                            model.HasIndividualDefaultSignature = true;
                        }
                        else if(model.DefaultSignatureId==null)
                        {
                            model.HasIndividualDefaultSignature = false;
                        }

                        if (model.ForwardReplySignatureId != null && model.ForwardReplySignatureId != emp.ForwardReplySignatureId)
                        {
                            model.HasIndividualForwardReplySignature = true;
                        }
                        else if(model.ForwardReplySignatureId == null)
                        {
                            model.HasIndividualForwardReplySignature = false;
                        }

                        emp.City = model.City;
                        emp.Company = model.Company;
                        emp.DepartmentId = model.DepartmentId;
                        emp.DisplayName = model.DisplayName;
                        emp.Email = model.Email;
                        emp.FaxNumber = model.FaxNumber;
                        emp.FirstName = model.FirstName;
                        emp.JobTitle = model.JobTitle;
                        emp.LastName = model.LastName;
                        emp.PhoneNumber = model.PhoneNumber;
                        emp.State = model.State;
                        emp.Street = model.Street;
                        emp.WebSite = model.WebSite;
                        emp.Zip = model.Zip;
                        emp.DefaultSignatureId = model.DefaultSignatureId;
                        emp.ForwardReplySignatureId = model.ForwardReplySignatureId;
                        emp.HasIndividualDefaultSignature =    model.HasIndividualDefaultSignature;
                        emp.HasIndividualForwardReplySignature = model.HasIndividualForwardReplySignature;
                        context.SaveChanges();
                      
                    }


                    return Json(emp);
                   
                }
                  

                  
            }
            catch
            {
                return View();
            }
        }

       

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(int employeeId)
        {

            Employee employee;
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                try
                {

                    employee = context.Employees.Find(employeeId);
                    if (employee != null)
                    {
                        context.Employees.Remove(employee);
                       // context.SaveChanges();
                        return Json(employee, JsonRequestBehavior.AllowGet);

                    }
                    else
                    {
                        return RedirectToAction("Create");
                    }
                    
                }
                catch
                {
                    return View();
                }
            }

          
        }
    }
}
