using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace SIMS.Models
{
    public partial class ClassDetail
    {
        public string ClassId { get; set; }
        public string StudentId { get; set; }


        [JsonIgnore]
        public virtual Class Class { get; set; }
        [JsonIgnore]
        public virtual Student Student { get; set; }
    }
}
