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
using System.Web.Http.Cors;
using System.Web.Http.Description;
using LSB.Data;
using LSB.Models;

namespace LSB.Controllers.Controllers
{

    public class UsersController : ApiController
    {
        private UserService userService = new UserService();
        //private LSBContext db = new LSBContext();

        // GET: api/Users
        public IQueryable<User> GetUsers()
        {
            return userService.Get();             
            //return db.Users;
        }

        // GET: api/Users/5
        [ResponseType(typeof(User))]
        public async Task<IHttpActionResult> GetUser(int id)
        {
            User user = await userService.GetbyUser(id);
            //db.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // PUT: api/Users/5
        [ResponseType(typeof(User))]
        public async Task<IHttpActionResult> PutUser(int id, User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user.UserID)
            {
                return BadRequest();
            }

            //db.Entry(user).State = EntityState.Modified;
            userService.SetState(user, EntityState.Modified);

            try
            {
                await userService.PutUser();
                //await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            
            return Ok(user);
        }

        // POST: api/Users
        [ResponseType(typeof(User))]
        public async Task<IHttpActionResult> PostUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await userService.PostUser(user);
            
            return CreatedAtRoute("DefaultApi", new { id = user.UserID }, user);
        }

        // DELETE: api/Users/5
        [ResponseType(typeof(User))]
        public async Task<IHttpActionResult> DeleteUser(int id)
        {
            User user = await userService.GetbyUser(id);
            if (user == null)
            {
                return null;
            }

            await userService.DeleteUser(user);

            return Ok(user);                       
        }

        protected override void Dispose(bool disposing)
        {        
            base.Dispose(disposing);
        }

        private bool UserExists(int id)
        {
            return userService.UserExists(id);
            
        }
    }
}