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
    public class InvestimentoesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Investimentoes
        public IQueryable<Investimento> GetInvestimentoes()
        {
            return db.Investimentoes;
        }

        // GET: api/Investimentoes/5
        [ResponseType(typeof(Investimento))]
        public IHttpActionResult GetInvestimento(int id)
        {
            Investimento investimento = db.Investimentoes.Find(id);
            if (investimento == null)
            {
                return NotFound();
            }

            return Ok(investimento);
        }

        // PUT: api/Investimentoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutInvestimento(int id, Investimento investimento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != investimento.InvestimentoId)
            {
                return BadRequest();
            }

            db.Entry(investimento).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InvestimentoExists(id))
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

        // POST: api/Investimentoes
        [ResponseType(typeof(Investimento))]
        public IHttpActionResult PostInvestimento(Investimento investimento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Investimentoes.Add(investimento);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = investimento.InvestimentoId }, investimento);
        }

        // DELETE: api/Investimentoes/5
        [ResponseType(typeof(Investimento))]
        public IHttpActionResult DeleteInvestimento(int id)
        {
            Investimento investimento = db.Investimentoes.Find(id);
            if (investimento == null)
            {
                return NotFound();
            }

            db.Investimentoes.Remove(investimento);
            db.SaveChanges();

            return Ok(investimento);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool InvestimentoExists(int id)
        {
            return db.Investimentoes.Count(e => e.InvestimentoId == id) > 0;
        }
    }
}