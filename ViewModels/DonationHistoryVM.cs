using CharityApplication.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace CharityApplication.ViewModels
{
    public class DonationHistoryVM
    {
        public string status { get; set; }
        public string transactionHash { get; set; }
        [DisplayName("User")]
        public string userName { get; set; }
        [DisplayName("Donation Amount")]
        public int amount { get; set; }
        [DisplayName("Date")]
        public string date { get; set; }
    }
}