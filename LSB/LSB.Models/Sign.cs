using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace LSB.Models
{
    public class Sign
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SignID { get; set; }
        public string SignVideoPath { get; set; }
        public string SignLanguage { get; set; }
        public Nullable<int> SignPoint { get; set; }
        public int WordID { get; set; }

        public virtual ICollection<Learning> Learning { get; set; }
        public virtual Word Word { get; set; }
    }
}
