using System;
using System.Collections.Generic;
using System.Text;
using LSB.Data;
using System.Data.Entity;
using LSB.Models;
using System.Threading.Tasks;

namespace LSB.Test
{
    public class TestContext : ILSBContext
    {
        public TestContext()
        {
            this.Users = new TestUserDbSet();
        }

    

        public DbSet<Learning> Learning { get; set; }

        public DbSet<Sign> Signs { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Word> Words { get; set; }


        public void MarkAsModified(User user) { }
        public void Dispose() { }

        public Task<int> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
        
    }
}
