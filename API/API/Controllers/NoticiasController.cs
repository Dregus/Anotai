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
    public class NoticiasController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Noticias
        public IQueryable<Noticia> GetNoticias()
        {
            return db.Noticias;
        }

        // GET: api/Noticias/5
        [ResponseType(typeof(Noticia))]
        public IHttpActionResult GetNoticia(int id)
        {
            Noticia noticia = db.Noticias.Find(id);
            if (noticia == null)
            {
                return NotFound();
            }

            return Ok(noticia);
        }

        // PUT: api/Noticias/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutNoticia(int id, Noticia noticia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != noticia.NoticiaId)
            {
                return BadRequest();
            }

            db.Entry(noticia).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NoticiaExists(id))
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

        // POST: api/Noticias
        [ResponseType(typeof(Noticia))]
        public IHttpActionResult PostNoticia(Noticia noticia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Noticias.Add(noticia);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = noticia.NoticiaId }, noticia);
        }

        // DELETE: api/Noticias/5
        [ResponseType(typeof(Noticia))]
        public IHttpActionResult DeleteNoticia(int id)
        {
            Noticia noticia = db.Noticias.Find(id);
            if (noticia == null)
            {
                return NotFound();
            }

            db.Noticias.Remove(noticia);
            db.SaveChanges();

            return Ok(noticia);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NoticiaExists(int id)
        {
            return db.Noticias.Count(e => e.NoticiaId == id) > 0;
        }
    }
}