using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace SIMS.Models
{
    public partial class Feedback
    {
        public string StudentId { get; set; }
        public string TeacherId { get; set; }
        public string Feedback1 { get; set; }


        [JsonIgnore]
        public virtual Student Student { get; set; }
        [JsonIgnore]
        public virtual Teacher Teacher { get; set; }
    }
}
