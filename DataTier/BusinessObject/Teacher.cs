using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace SIMS.DataTier.BusinessObject
{
    public partial class Teacher
    {
        public Teacher()
        {
            Classes = new HashSet<Class>();
            Feedbacks = new HashSet<Feedback>();
        }

        public string TeacherId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public decimal? Phone { get; set; }
        public string Faculty { get; set; }

        [JsonIgnore]
        public virtual ICollection<Class> Classes { get; set; }
        [JsonIgnore]
        public virtual ICollection<Feedback> Feedbacks { get; set; }
    }
}
