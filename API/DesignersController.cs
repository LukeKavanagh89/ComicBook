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
using ComicStore.Models;

namespace ComicStore.API
{
    public class DesignersController : ApiController
    {
        private ComicStoreContext db = new ComicStoreContext();

        // GET: api/Designers
        public IQueryable<Designer> GetDesigners()
        {
            return db.Designers;
        }

        // GET: api/Designers/5
        [ResponseType(typeof(Designer))]
        public IHttpActionResult GetDesigner(int id)
        {
            Designer designer = db.Designers.Find(id);
            if (designer == null)
            {
                return NotFound();
            }

            return Ok(designer);
        }

        // PUT: api/Designers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDesigner(int id, Designer designer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != designer.DesignerId)
            {
                return BadRequest();
            }

            db.Entry(designer).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DesignerExists(id))
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

        // POST: api/Designers
        [ResponseType(typeof(Designer))]
        public IHttpActionResult PostDesigner(Designer designer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Designers.Add(designer);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = designer.DesignerId }, designer);
        }

        // DELETE: api/Designers/5
        [ResponseType(typeof(Designer))]
        public IHttpActionResult DeleteDesigner(int id)
        {
            Designer designer = db.Designers.Find(id);
            if (designer == null)
            {
                return NotFound();
            }

            db.Designers.Remove(designer);
            db.SaveChanges();

            return Ok(designer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DesignerExists(int id)
        {
            return db.Designers.Count(e => e.DesignerId == id) > 0;
        }
    }
}