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
    public class SignsController : ApiController
    {
        private LSBContext db = new LSBContext();

        // GET: api/Signs
        public IQueryable<Sign> GetSigns()
        {
            return db.Signs;
        }

        // GET: api/Signs/5
        [ResponseType(typeof(Sign))]
        public async Task<IHttpActionResult> GetSign(int id)
        {
            Sign sign = await db.Signs.FindAsync(id);
            if (sign == null)
            {
                return NotFound();
            }

            return Ok(sign);
        }

        // PUT: api/Signs/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSign(int id, Sign sign)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sign.SignID)
            {
                return BadRequest();
            }

            db.Entry(sign).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SignExists(id))
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

        // POST: api/Signs
        [ResponseType(typeof(Sign))]
        public async Task<IHttpActionResult> PostSign(Sign sign)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Signs.Add(sign);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = sign.SignID }, sign);
        }

        // DELETE: api/Signs/5
        [ResponseType(typeof(Sign))]
        public async Task<IHttpActionResult> DeleteSign(int id)
        {
            Sign sign = await db.Signs.FindAsync(id);
            if (sign == null)
            {
                return NotFound();
            }

            db.Signs.Remove(sign);
            await db.SaveChangesAsync();

            return Ok(sign);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SignExists(int id)
        {
            return db.Signs.Count(e => e.SignID == id) > 0;
        }
    }
}