using CharityApplication.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CharityApplication.ViewModels
{
    public class UserIndexViewModel
    {
        public List<cause> causes { get; set; }
        public Dictionary<int, string> orgMap { get; set; }
        public int row { get; set; }
        public int cols { get; set; }

    }
}