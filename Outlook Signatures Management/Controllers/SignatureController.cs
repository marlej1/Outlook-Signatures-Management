using Outlook_Signatures_Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Outlook_Signatures_Management.Controllers
{
    public class SignatureController : Controller
    {
        
        // GET: Signtature
        public ActionResult Index()
        {
            List<Signature> signatures;
            using (ApplicationDbContext context = new ApplicationDbContext())
            {

                signatures = context.Signatures.ToList();

            }
            return View(signatures);
        }

        // GET: Signtature/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Signtature/Create
        [ChildActionOnly]
        public ActionResult Create()
        {
            return PartialView("_Create");
        }

        // POST: Signtature/Create
        [HttpPost]
        public ActionResult Create(Signature model)
        {
            model.DateAdded = DateTime.Now;
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                try
                {
                    context.Signatures.Add(model);
                    context.SaveChanges();
                    // TODO: Add insert logic here

                    return Json(model);
                }
                catch (Exception ex)
                {
                    return Content(ex.Message);
                }
            }
        }

        // GET: Signtature/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Signtature/Edit/5
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

        // GET: Signtature/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Signtature/Delete/5
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
