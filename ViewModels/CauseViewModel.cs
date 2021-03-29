using CharityApplication.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CharityApplication.ViewModels
{
    public class CauseViewModel
    {
        public cause Cause { get; set; }
        public organization Organization { get; set; }

    }
}