using CharityApplication.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace CharityApplication.ViewModels
{
    public class DonationViewModel:donation
    {
        [DisplayName("Organization Name")]
        public string orgName { get; set; }
        [DisplayName("Cause Name")]
        public string causeName { get; set; }
    }
}