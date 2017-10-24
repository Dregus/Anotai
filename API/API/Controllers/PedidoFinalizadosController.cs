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
    public class PedidoFinalizadosController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/PedidoFinalizados
        public IQueryable<PedidoFinalizado> GetPedidoFinalizadoes()
        {
            return db.PedidoFinalizadoes;
        }

        // GET: api/PedidoFinalizados/5
        [ResponseType(typeof(PedidoFinalizado))]
        public IHttpActionResult GetPedidoFinalizado(int id)
        {
            PedidoFinalizado pedidoFinalizado = db.PedidoFinalizadoes.Find(id);
            if (pedidoFinalizado == null)
            {
                return NotFound();
            }

            return Ok(pedidoFinalizado);
        }

        // PUT: api/PedidoFinalizados/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPedidoFinalizado(int id, PedidoFinalizado pedidoFinalizado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pedidoFinalizado.PedidoFinalizadoId)
            {
                return BadRequest();
            }

            db.Entry(pedidoFinalizado).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PedidoFinalizadoExists(id))
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

        // POST: api/PedidoFinalizados
        [ResponseType(typeof(PedidoFinalizado))]
        public IHttpActionResult PostPedidoFinalizado(PedidoFinalizado pedidoFinalizado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PedidoFinalizadoes.Add(pedidoFinalizado);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = pedidoFinalizado.PedidoFinalizadoId }, pedidoFinalizado);
        }

        // DELETE: api/PedidoFinalizados/5
        [ResponseType(typeof(PedidoFinalizado))]
        public IHttpActionResult DeletePedidoFinalizado(int id)
        {
            PedidoFinalizado pedidoFinalizado = db.PedidoFinalizadoes.Find(id);
            if (pedidoFinalizado == null)
            {
                return NotFound();
            }

            db.PedidoFinalizadoes.Remove(pedidoFinalizado);
            db.SaveChanges();

            return Ok(pedidoFinalizado);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PedidoFinalizadoExists(int id)
        {
            return db.PedidoFinalizadoes.Count(e => e.PedidoFinalizadoId == id) > 0;
        }
    }
}