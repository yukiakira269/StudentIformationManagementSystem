using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace SIMS.DataTier.BusinessObject
{
    public partial class Student
    {
        public Student()
        {
            ClassDetails = new HashSet<ClassDetail>();
            Feedbacks = new HashSet<Feedback>();
        }

        public string StudentId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public decimal? ParentsPhone { get; set; }
        public DateTime? Dob { get; set; }
        public string Avatar { get; set; }
        public double? Gpa { get; set; }

        [JsonIgnore]
        public virtual Parent StudentNavigation { get; set; }
        [JsonIgnore]
        public virtual ICollection<ClassDetail> ClassDetails { get; set; }
        [JsonIgnore]
        public virtual ICollection<Feedback> Feedbacks { get; set; }
    }
}
