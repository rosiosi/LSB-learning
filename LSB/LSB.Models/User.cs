using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace LSB.Models
{
    [Serializable]
    [JsonObject]
    public class User
    {

   
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string UserLastName { get; set; }
        public string UserUserName { get; set; }
        public Nullable<System.DateTime> UserBirthDate { get; set; }
        public string UserCellPhoneNumber { get; set; }


        public virtual ICollection<Learning> Learning { get; set; }
    
    }
}
