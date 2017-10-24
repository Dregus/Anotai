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
    public class PacotesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Pacotes
        public IQueryable<Pacote> GetPacotes()
        {
            return db.Pacotes;
        }

        // GET: api/Pacotes/5
        [ResponseType(typeof(Pacote))]
        public IHttpActionResult GetPacote(int id)
        {
            Pacote pacote = db.Pacotes.Find(id);
            if (pacote == null)
            {
                return NotFound();
            }

            return Ok(pacote);
        }

        // PUT: api/Pacotes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPacote(int id, Pacote pacote)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pacote.PacoteId)
            {
                return BadRequest();
            }

            db.Entry(pacote).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PacoteExists(id))
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

        // POST: api/Pacotes
        [ResponseType(typeof(Pacote))]
        public IHttpActionResult PostPacote(Pacote pacote)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Pacotes.Add(pacote);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = pacote.PacoteId }, pacote);
        }

        // DELETE: api/Pacotes/5
        [ResponseType(typeof(Pacote))]
        public IHttpActionResult DeletePacote(int id)
        {
            Pacote pacote = db.Pacotes.Find(id);
            if (pacote == null)
            {
                return NotFound();
            }

            db.Pacotes.Remove(pacote);
            db.SaveChanges();

            return Ok(pacote);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PacoteExists(int id)
        {
            return db.Pacotes.Count(e => e.PacoteId == id) > 0;
        }
    }
}