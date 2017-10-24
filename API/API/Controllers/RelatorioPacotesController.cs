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
using API.Models;

namespace API.Controllers
{
    public class RelatorioPacotesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/RelatorioPacotes
        public IQueryable<RelatorioPacote> GetRelatorioPacotes()
        {
            return db.RelatorioPacotes;
        }

        // GET: api/RelatorioPacotes/5
        [ResponseType(typeof(RelatorioPacote))]
        public IHttpActionResult GetRelatorioPacote(int id)
        {
            RelatorioPacote relatorioPacote = db.RelatorioPacotes.Find(id);
            if (relatorioPacote == null)
            {
                return NotFound();
            }

            return Ok(relatorioPacote);
        }

        // PUT: api/RelatorioPacotes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRelatorioPacote(int id, RelatorioPacote relatorioPacote)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != relatorioPacote.RelatorioPacoteId)
            {
                return BadRequest();
            }

            db.Entry(relatorioPacote).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RelatorioPacoteExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/RelatorioPacotes
        [ResponseType(typeof(RelatorioPacote))]
        public IHttpActionResult PostRelatorioPacote(RelatorioPacote relatorioPacote)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RelatorioPacotes.Add(relatorioPacote);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = relatorioPacote.RelatorioPacoteId }, relatorioPacote);
        }

        // DELETE: api/RelatorioPacotes/5
        [ResponseType(typeof(RelatorioPacote))]
        public IHttpActionResult DeleteRelatorioPacote(int id)
        {
            RelatorioPacote relatorioPacote = db.RelatorioPacotes.Find(id);
            if (relatorioPacote == null)
            {
                return NotFound();
            }

            db.RelatorioPacotes.Remove(relatorioPacote);
            db.SaveChanges();

            return Ok(relatorioPacote);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RelatorioPacoteExists(int id)
        {
            return db.RelatorioPacotes.Count(e => e.RelatorioPacoteId == id) > 0;
        }
    }
}