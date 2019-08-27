using LSB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSB.Data{
    
    public class LSBInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<LSBContext>
    {
        protected override void Seed(LSBContext context)
        {
            var students = new List<User>
            {
                new User{ UserID = 3451323, UserName = "Armando", UserLastName = "Villan", UserUserName = "manuido", UserCellPhoneNumber = "+ 591 72243490", UserBirthDate = DateTime.Parse("1984-09-01")},
                new User{ UserID = 3076343, UserName = "Rosa", UserLastName = "Osinaga", UserUserName = "rosiosi", UserCellPhoneNumber = "+ 591 73007325", UserBirthDate = DateTime.Parse("1988-09-01")}

            };

            students.ForEach(s => context.Users.Add(s));
            context.SaveChanges();
        }
    }
}
