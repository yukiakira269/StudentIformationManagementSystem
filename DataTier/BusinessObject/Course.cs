using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace SIMS.Models
{
    public partial class Course
    {
        public Course()
        {
            Classes = new HashSet<Class>();
            Grades = new HashSet<Grade>();
        }

        public string CourseId { get; set; }
        public string Name { get; set; }
        public float? Fee { get; set; }

        [JsonIgnore]
        public virtual ICollection<Class> Classes { get; set; }
        [JsonIgnore]
        public virtual ICollection<Grade> Grades { get; set; }
    }
}
