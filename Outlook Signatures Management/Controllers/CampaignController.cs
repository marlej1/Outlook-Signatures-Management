using Outlook_Signatures_Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Outlook_Signatures_Management.Controllers
{
    public class CampaignController : Controller
    {
        // GET: Campaign
        public ActionResult Index()
        {
            List<Campaign> campaigns;
            using (ApplicationDbContext context = new ApplicationDbContext())
            {

                campaigns = context.Campaigns.ToList();

            }
            return View(campaigns);
        }

        // GET: Campaign/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Campaign/Create
        public ActionResult Create()
        {
            return PartialView("_Create");
        }

        // POST: Campaign/Create
        [HttpPost]
        public ActionResult Create(Campaign model)
        {
            model.DateAdded = DateTime.Now;
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                try
                {
                    context.Campaigns.Add(model);
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

        // GET: Campaign/Edit/5
        public ActionResult Edit(int campaignId)
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                var campaign = context.Campaigns.Find(campaignId);
                if (campaign != null)
                {
                    return PartialView("_Edit", campaign);
                }
            }
            return HttpNotFound();
        }

        // POST: Campaign/Edit/5
        [HttpPost]
        public ActionResult Edit(Campaign model)
        {
            Campaign campaign;
            using (ApplicationDbContext context = new ApplicationDbContext())
            {


                campaign = context.Campaigns.Find(model.CampaignId);
                if (campaign != null)
                {
                    campaign.CampaignName = model.CampaignName;
                    campaign.Content = model.Content;
                    campaign.Enabled = model.Enabled;
                    campaign.EndDate = model.EndDate;
                    campaign.IsAlwaysActive = model.IsAlwaysActive;
                    campaign.SideNotes = model.SideNotes;
                    campaign.StartDate = model.StartDate;

                    context.SaveChanges();

                    return Json(campaign);
                }
                return HttpNotFound();
            }
        }

       

        // POST: Campaign/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                Campaign campaign;
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    campaign = db.Campaigns.Find(id);
                    if (campaign != null)
                    {
                        db.Campaigns.Remove(campaign);
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
