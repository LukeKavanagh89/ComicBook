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
    public class CreatorsController : ApiController
    {
        private ComicStoreContext db = new ComicStoreContext();

        // GET: api/Creators
        public IQueryable<Creator> GetCreators()
        {
            return db.Creators;
        }

        // GET: api/Creators/5
        [ResponseType(typeof(Creator))]
        public IHttpActionResult GetCreator(int id)
        {
            Creator creator = db.Creators.Find(id);
            if (creator == null)
            {
                return NotFound();
            }

            return Ok(creator);
        }

        // PUT: api/Creators/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCreator(int id, Creator creator)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != creator.CreatorId)
            {
                return BadRequest();
            }

            db.Entry(creator).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CreatorExists(id))
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

        // POST: api/Creators
        [ResponseType(typeof(Creator))]
        public IHttpActionResult PostCreator(Creator creator)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Creators.Add(creator);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = creator.CreatorId }, creator);
        }

        // DELETE: api/Creators/5
        [ResponseType(typeof(Creator))]
        public IHttpActionResult DeleteCreator(int id)
        {
            Creator creator = db.Creators.Find(id);
            if (creator == null)
            {
                return NotFound();
            }

            db.Creators.Remove(creator);
            db.SaveChanges();

            return Ok(creator);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CreatorExists(int id)
        {
            return db.Creators.Count(e => e.CreatorId == id) > 0;
        }
    }
}