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
    public class RelatorioInvestidorsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/RelatorioInvestidors
        public IQueryable<RelatorioInvestidor> GetRelatorioInvestidors()
        {
            return db.RelatorioInvestidors;
        }

        // GET: api/RelatorioInvestidors/5
        [ResponseType(typeof(RelatorioInvestidor))]
        public IHttpActionResult GetRelatorioInvestidor(int id)
        {
            RelatorioInvestidor relatorioInvestidor = db.RelatorioInvestidors.Find(id);
            if (relatorioInvestidor == null)
            {
                return NotFound();
            }

            return Ok(relatorioInvestidor);
        }

        // PUT: api/RelatorioInvestidors/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRelatorioInvestidor(int id, RelatorioInvestidor relatorioInvestidor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != relatorioInvestidor.RelatorioInvestidorId)
            {
                return BadRequest();
            }

            db.Entry(relatorioInvestidor).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RelatorioInvestidorExists(id))
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

        // POST: api/RelatorioInvestidors
        [ResponseType(typeof(RelatorioInvestidor))]
        public IHttpActionResult PostRelatorioInvestidor(RelatorioInvestidor relatorioInvestidor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RelatorioInvestidors.Add(relatorioInvestidor);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = relatorioInvestidor.RelatorioInvestidorId }, relatorioInvestidor);
        }

        // DELETE: api/RelatorioInvestidors/5
        [ResponseType(typeof(RelatorioInvestidor))]
        public IHttpActionResult DeleteRelatorioInvestidor(int id)
        {
            RelatorioInvestidor relatorioInvestidor = db.RelatorioInvestidors.Find(id);
            if (relatorioInvestidor == null)
            {
                return NotFound();
            }

            db.RelatorioInvestidors.Remove(relatorioInvestidor);
            db.SaveChanges();

            return Ok(relatorioInvestidor);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RelatorioInvestidorExists(int id)
        {
            return db.RelatorioInvestidors.Count(e => e.RelatorioInvestidorId == id) > 0;
        }
    }
}