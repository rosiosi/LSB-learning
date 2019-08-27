using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace LSB.Models
{
    [Serializable]
    [JsonObject]
    public class Word
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WordID { get; set; }        

        public string WordDefinition { get; set; }
        public string WordImagePath { get; set; }

        public virtual ICollection<Sign> Signs { get; set; }
    }
}
