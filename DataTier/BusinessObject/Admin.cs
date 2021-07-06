using System;
using System.Collections.Generic;

#nullable disable

namespace SIMS.DataTier.BusinessObject
{
    public partial class Admin
    {
        public string AdminId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public decimal? Phone { get; set; }
    }
}
