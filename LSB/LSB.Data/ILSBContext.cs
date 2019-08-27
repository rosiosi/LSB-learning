using LSB.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSB.Data
{
    public interface ILSBContext : IDisposable
    {
        DbSet<Learning> Learning { get; }
        DbSet<Sign> Signs { get; }
        DbSet<User> Users { get; }
        DbSet<Word> Words { get; }
        Task<int> SaveChangesAsync();
        void MarkAsModified(User item);
    }
}
