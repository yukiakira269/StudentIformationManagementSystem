using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace SIMS.DataTier.BusinessObject
{
    public partial class Parent
    {
        public string StudentId { get; set; }
        public string Email { get; set; }
        public decimal? Phone { get; set; }
        public float? Balance { get; set; }

        [JsonIgnore]
        public virtual Student Student { get; set; }
    }
}
