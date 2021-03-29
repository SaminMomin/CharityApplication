using CharityApplication.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CharityApplication.ViewModels
{
    public class DonationViewModel:donation
    {
        public string orgName { get; set; }
        public string causeName { get; set; }
    }
}