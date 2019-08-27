using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LSB.Data;
using LSB.Models;


namespace LSB.Data
{
    
    public  class UserService
    {
        //private  LSBContext db = new LSBContext();
        private ILSBContext db = new LSBContext();

        public UserService()
        { }

        public UserService(ILSBContext context)
        {
            db = context;
        }

        public IQueryable<User> Get()
        {
            return db.Users;
        }

        public async Task<User> GetbyUser(int id)
        {
            return await db.Users.FindAsync(id);
        }

        public bool UserExists(int id)
        {
            return db.Users.Count(e => e.UserID == id) > 0;
        }

        

        public async Task<User> DeleteUser(User user)
        {            

            db.Users.Remove(user);
            await db.SaveChangesAsync();

            return user;
        }

        public async Task PostUser(User user)
        {
            db.Users.Add(user);
            await db.SaveChangesAsync();
        }

        public async Task PutUser()
        {
            //db.Entry(user).State = modified;
            await db.SaveChangesAsync();
        }

        public void SetState(User user, EntityState modified)
        {
            //db.Entry(user).State = modified;
            db.MarkAsModified(user);
        }
    }
}
