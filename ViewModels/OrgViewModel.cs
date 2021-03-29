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
        public organization org { get; set; }
        public IEnumerable<cause> causes { get; set; }
        public int row { get; set; }
        public int cols { get; set; }
        public int fundsCollected { get; set; }
        public int totalUsers { get; set; }
    }
}