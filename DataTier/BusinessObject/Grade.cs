using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

#nullable disable

namespace SIMS.DataTier.BusinessObject
{
    public partial class Grade
    {
        public string StudentId { get; set; }
        public string CourseId { get; set; }
        public double? Grade1 { get; set; }

        [JsonIgnore]
        public virtual Course Course { get; set; }
    }
}
