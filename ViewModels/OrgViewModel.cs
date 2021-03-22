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
        public organization orga { get; set; }
        public IEnumerable<TypeList> types { get; set; }
    }
}