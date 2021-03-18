using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CharityApplication.Models
{
    public class User:BaseEntity
    {
        public string fname { get; set; }
        public string lname { get; set; }
        public int age { get; set; }
        public string password { get; set; }
        public System.DateTime dob { get; set; }
        public string contact { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public string email { get; set; }
        public Nullable<int> hash { get; set; }
    }
}