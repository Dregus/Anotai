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
    public class ComandasController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Comandas
        public IQueryable<Comanda> GetComandas()
        {
            return db.Comandas;
        }

        // GET: api/Comandas/5
        [ResponseType(typeof(Comanda))]
        public IHttpActionResult GetComanda(int id)
        {
            //Comanda comanda = db.Comandas.Find(id);
            Comanda comanda = db.Comandas.Where(m => m.DonoComandaId == id).First();
            if (comanda == null)
            {
                return NotFound();
            }

            return Ok(comanda);
        }

        // PUT: api/Comandas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutComanda(int id, Comanda comanda)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != comanda.ComandaId)
            {
                return BadRequest();
            }

            db.Entry(comanda).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComandaExists(id))
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

        // POST: api/Comandas
        [ResponseType(typeof(Comanda))]
        public IHttpActionResult PostComanda([FromBody] Comanda comanda)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Comandas.Add(comanda);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = comanda.ComandaId }, comanda);
        }

        // DELETE: api/Comandas/5
        [ResponseType(typeof(Comanda))]
        public IHttpActionResult DeleteComanda(int id)
        {
            Comanda comanda = db.Comandas.Find(id);
            if (comanda == null)
            {
                return NotFound();
            }

            db.Comandas.Remove(comanda);
            db.SaveChanges();

            return Ok(comanda);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ComandaExists(int id)
        {
            return db.Comandas.Count(e => e.ComandaId == id) > 0;
        }
    }
}