using CharityApplication.Database;
using CharityApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CharityApplication.ViewModels
{
    public class OrgViewModel
    {
        public int totalCauses { get; set; }
        public organization org { get; set; }
        public IEnumerable<cause> activeCauses { get; set; }
        public IEnumerable<cause> completedCauses { get; set; }

        public int row { get; set; }
        public int crow { get; set; }
        public int cols { get; set; }
        public int ccols { get; set; }
        public int fundsCollected { get; set; }
        public int totalUsers { get; set; }
    }
}