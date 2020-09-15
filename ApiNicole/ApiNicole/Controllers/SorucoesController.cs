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
using ApiNicole.Models;

namespace ApiNicole.Controllers
{
    public class SorucoesController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Sorucoes
        [Authorize]
        public IQueryable<Soruco> GetSorucoes()
        {
            return db.Sorucoes;
        }

        // GET: api/Sorucoes/5
        [Authorize]
        [ResponseType(typeof(Soruco))]
        public IHttpActionResult GetSoruco(int id)
        {
            Soruco soruco = db.Sorucoes.Find(id);
            if (soruco == null)
            {
                return NotFound();
            }

            return Ok(soruco);
        }

        // PUT: api/Sorucoes/5
        [Authorize]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSoruco(int id, Soruco soruco)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != soruco.SorucoID)
            {
                return BadRequest();
            }

            db.Entry(soruco).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SorucoExists(id))
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

        // POST: api/Sorucoes
        [Authorize]
        [ResponseType(typeof(Soruco))]
        public IHttpActionResult PostSoruco(Soruco soruco)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Sorucoes.Add(soruco);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = soruco.SorucoID }, soruco);
        }

        // DELETE: api/Sorucoes/5
        [Authorize]
        [ResponseType(typeof(Soruco))]
        public IHttpActionResult DeleteSoruco(int id)
        {
            Soruco soruco = db.Sorucoes.Find(id);
            if (soruco == null)
            {
                return NotFound();
            }

            db.Sorucoes.Remove(soruco);
            db.SaveChanges();

            return Ok(soruco);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SorucoExists(int id)
        {
            return db.Sorucoes.Count(e => e.SorucoID == id) > 0;
        }
    }
}