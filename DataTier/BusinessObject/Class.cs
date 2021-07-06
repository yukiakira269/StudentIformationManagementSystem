using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace SIMS.DataTier.BusinessObject
{
    public partial class Class
    {
        public Class()
        {
            ClassDetails = new HashSet<ClassDetail>();
        }

        public string ClassId { get; set; }
        public string CourseId { get; set; }
        public string TeacherId { get; set; }
        public int? NumOfStudent { get; set; }

        [JsonIgnore]
        public virtual Course Course { get; set; }
        [JsonIgnore]
        public virtual Teacher Teacher { get; set; }
        [JsonIgnore]
        public virtual ICollection<ClassDetail> ClassDetails { get; set; }
    }
}
