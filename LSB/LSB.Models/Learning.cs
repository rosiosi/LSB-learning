using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations.Schema;


namespace LSB.Models
{
    [Serializable]
    [JsonObject]
    public class Learning
        {
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int LearningID { get; set; }
            public int UserID { get; set; }
            public int SignID { get; set; }

            public virtual Sign Sign { get; set; }
            public virtual User User { get; set; }
        }
    
}
