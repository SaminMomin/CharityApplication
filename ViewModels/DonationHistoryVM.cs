using CharityApplication.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CharityApplication.ViewModels
{
    public class DonationHistoryVM
    {
        public string status { get; set; }
        public string transactionHash { get; set; }
        public string userName { get; set; }
        public int amount { get; set; }
        public string date { get; set; }
    }
}