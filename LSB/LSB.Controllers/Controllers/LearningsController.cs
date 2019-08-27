using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using LSB.Data;
using LSB.Models;

namespace LSB.Controllers.Controllers
{
    public class LearningsController : ApiController
    {
        private LSBContext db = new LSBContext();

        // GET: api/Learnings
        public IQueryable<Learning> GetLearning()
        {
            return db.Learning;
        }

        // GET: api/Learnings/5
        [ResponseType(typeof(Learning))]
        public async Task<IHttpActionResult> GetLearning(int id)
        {
            Learning learning = await db.Learning.FindAsync(id);
            if (learning == null)
            {
                return NotFound();
            }

            return Ok(learning);
        }

        // PUT: api/Learnings/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutLearning(int id, Learning learning)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != learning.LearningID)
            {
                return BadRequest();
            }

            db.Entry(learning).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LearningExists(id))
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

        // POST: api/Learnings
        [ResponseType(typeof(Learning))]
        public async Task<IHttpActionResult> PostLearning(Learning learning)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Learning.Add(learning);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = learning.LearningID }, learning);
        }

        // DELETE: api/Learnings/5
        [ResponseType(typeof(Learning))]
        public async Task<IHttpActionResult> DeleteLearning(int id)
        {
            Learning learning = await db.Learning.FindAsync(id);
            if (learning == null)
            {
                return NotFound();
            }

            db.Learning.Remove(learning);
            await db.SaveChangesAsync();

            return Ok(learning);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LearningExists(int id)
        {
            return db.Learning.Count(e => e.LearningID == id) > 0;
        }
    }
}