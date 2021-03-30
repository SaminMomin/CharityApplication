using CharityApplication.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace CharityApplication.ViewModels
{
    public class UserViewModel
    {
        public int? userId { get; set; }
        [DisplayName("Donation Amount")]
        public int amount { get; set; }
        [DisplayName("Organization")]
        public string organization { get; set; }
        public int orgId { get; set; }
        [DisplayName("Cause")]
        public string cause { get; set; }
        public  int causeId { get; set; }
        [DisplayName("Date")]
        public string time { get; set; }
        public string transactionHash { get; set; }
    }
}