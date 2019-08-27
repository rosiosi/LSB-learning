using LSB.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSB.Data
{
    public class LSBContext : DbContext, ILSBContext
    {

        public LSBContext()
            : base("name=LSBContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<Learning> Learning { get; set; }
        public virtual DbSet<Sign> Signs { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Word> Words { get; set; }

        public void MarkAsModified(User user)
        {
            Entry(user).State = EntityState.Modified;
        }

    }
}
