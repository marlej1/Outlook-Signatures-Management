using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Outlook_Signatures_Management.Models;

namespace Outlook_Signatures_Management.Controllers
{
    public class SignaturesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Signatures
        public IQueryable<Signature> GetSignatures()
        {
            return db.Signatures;
        }

        // GET: api/Signatures/5
        [ResponseType(typeof(Signature))]
        public IHttpActionResult GetSignature(int id)
        {
            Signature signature = db.Signatures.Find(id);
            if (signature == null)
            {
                return NotFound();
            }

            return Ok(signature);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SignatureExists(int id)
        {
            return db.Signatures.Count(e => e.SignatureId == id) > 0;
        }
    }
}