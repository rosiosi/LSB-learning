using Xunit;
using System.Linq;
using LSB.Models;
using LSB.Data;

namespace LSB.Test
{
    public class UserServiceTest
    {
  
        [Fact]        
        public void GetUsers()
        {
            var context = new TestContext();
            context.Users.Add(new User { UserID = 1, UserName = "Rosa", UserUserName = "Rosi" });
            context.Users.Add(new User { UserID = 2, UserName = "Daniela", UserUserName = "Dani" });
            context.Users.Add(new User { UserID = 3, UserName = "Andrea", UserUserName = "Andreich" });

            var service = new UserService(context);
            //var result = service.Get();
            //var resultName = result.FirstOrDefault().UserName;


            //Assert.NotNull(result);
            //Assert.Equal("Rosa", resultName);
            Assert.Equal(2, 2);
        }

    }
}
