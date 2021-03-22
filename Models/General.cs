using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CharityApplication.Models
{
    public static class General
    {
        public static int orgId;
        public static string orgName;
        public static bool userLoginStatus = false;
        public static bool orgLoginStatus = false;
        public static int userId;
        public static string userName;
        public static IEnumerable<TypeList> typeCollection()
        {
            List<TypeList> lister = new List<TypeList>();
 //, , , , , " };

            lister.Add(new TypeList { type="Animal Charity"});
            lister.Add(new TypeList { type = "Environmental Charity" });
            lister.Add(new TypeList { type = "International NGO" });
            lister.Add(new TypeList { type = "Health Charity" });
            lister.Add(new TypeList { type = "Education Charity" });
            lister.Add(new TypeList { type = "Arts and Culture Charity" });

            return lister;
}
    }
}