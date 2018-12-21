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
                    if (model.IsDefault)
                        AssignDefaultSignature(model.SignatureId);
                    if (model.IsForwardReply)
                        AssignForwardReplySignature(model.SignatureId);
                    // TODO: Add insert logic here

                    return Json(model);
                }
                catch (Exception ex)
                {
                    return Content(ex.Message);
                }
            }
        }

        private void AssignDefaultSignature(int id)
        {
            IEnumerable<Employee> employeesWithoutDefaultSign;
            IEnumerable<Signature> signatures;


            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                signatures = context.Signatures.Where(s => s.SignatureId!=id);
                foreach (var sign in signatures)
                {
                    sign.IsDefault = false;
                }
                employeesWithoutDefaultSign = context.Employees.ToList().Where(e => !e.HasIndividualDefaultSignature).ToList();

                foreach (var employee in employeesWithoutDefaultSign)
                {
                    employee.DefaultSignatureId = id;
                }
                context.SaveChanges();


            }
        }

        private void AssignForwardReplySignature(int id)
        {
            IEnumerable<Employee> employeesWithoutReplySign;
            IEnumerable<Signature> signatures;

            using (ApplicationDbContext context = new ApplicationDbContext())
            {

                signatures = context.Signatures.Where(s => s.SignatureId != id);
                foreach (var sign in signatures)
                {
                    sign.IsForwardReply = false;
                }
                employeesWithoutReplySign = context.Employees.ToList().Where(e => !e.HasIndividualForwardReplySignature);

                foreach (var employee in employeesWithoutReplySign)
                {
                    employee.ForwardReplySignatureId = id;
                }
                context.SaveChanges();



            }
        }

        // GET: Signtature/Edit/5
        public ActionResult Edit(int signatureId)
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                var signature = context.Signatures.Find(signatureId);
                if (signature != null)
                {
                    return PartialView("_Edit", signature);
                }
            }
            return HttpNotFound();
        }

        // POST: Signtature/Edit/5
        [HttpPost]
        public ActionResult Edit(Signature model)
        {
            Signature sign; 
            using (ApplicationDbContext context = new ApplicationDbContext())
            {


                sign = context.Signatures.Find(model.SignatureId);
                if (sign != null)
                {

                    sign.SignatureName = model.SignatureName;
                    sign.Notes = model.Notes;
                    sign.Body = model.Body;
                    sign.IsDefault = model.IsDefault;
                    sign.IsForwardReply = model.IsForwardReply;
                    sign.IsOptional = model.IsOptional;
                    context.SaveChanges();

                    if (sign.IsDefault)
                        AssignDefaultSignature(sign.SignatureId);
                    if (sign.IsForwardReply)
                        AssignForwardReplySignature(sign.SignatureId);

                    return Json(sign);
                }
                return HttpNotFound();
                        
            }

            
          
            
        }

      
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                Signature signature;
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    signature = db.Signatures.Find(id);
                    if (signature!=null)
                    {
                        db.Signatures.Remove(signature);
                        db.SaveChanges();
                        
                    }
                }
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
