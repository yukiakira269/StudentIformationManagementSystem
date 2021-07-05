using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace SIMS.Models
{
    public partial class Grade
    {
        public string StudentId { get; set; }
        public string CourseId { get; set; }
        public double? ComponentGrade { get; set; }
        public string Component { get; set; }

        [JsonIgnore]
        public virtual Course Course { get; set; }
        [JsonIgnore]
        public virtual Student Student { get; set; }
    }
}
