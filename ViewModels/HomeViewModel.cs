using CharityApplication.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CharityApplication.ViewModels
{
    public class HomeViewModel
    {
        public List<cause> Causes { get; set; }
        public List<organization> Organizations { get; set; }
        public int rows { get; set; }
        public int cols { get; set; }
        public int userCount { get; set; }
        public int organizationCount { get; set; }
        public int donationCount { get; set; }
        public int causeCount { get; set; }

    }
    
}