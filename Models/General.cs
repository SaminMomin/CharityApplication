using System.Collections.Generic;
	
namespace CharityApplication.Models
{
    public class General
    {
        public static int orgId;
        public static string orgName;
        public static bool userLoginStatus = false;
        public static bool orgLoginStatus = false;
        public static int userId;
        public static string userName;
        public static string userTx;
        public static string orgTx;
        public static bool useremailStatus = false;
        public static bool orgemailStatus = false;
        public static IEnumerable<TypeList> typeCollection()
        {
            List<TypeList> lister = new List<TypeList>();
            lister.Add(new TypeList { type="Animal Charity"});
            lister.Add(new TypeList { type = "Environmental Charity" });
            lister.Add(new TypeList { type = "International NGO" });
            lister.Add(new TypeList { type = "Health Charity" });
            lister.Add(new TypeList { type = "Education Charity" });
            lister.Add(new TypeList { type = "Arts and Culture Charity" });
            return lister;
	}
        public static IEnumerable<TypeList> causeCollection()
        {
            List<TypeList> lister = new List<TypeList>();
            lister.Add(new TypeList { type = "Community" });
            lister.Add(new TypeList { type = "Housing" });
            lister.Add(new TypeList { type = "Overseas Aid" });
            lister.Add(new TypeList { type = "Poverty Relief" });
            lister.Add(new TypeList { type = "Training" });
            lister.Add(new TypeList { type = "Medical" });
            lister.Add(new TypeList { type = "Sports Clubs" });
            lister.Add(new TypeList { type = "Arts and Culture" });
            lister.Add(new TypeList { type = "Public Service and Military" });
            lister.Add(new TypeList { type = "Education" });
            lister.Add(new TypeList { type = "Children's" });
            lister.Add(new TypeList { type = "Disability" });
            lister.Add(new TypeList { type = "Environmental" });
            lister.Add(new TypeList { type = "Religious" });
            lister.Add(new TypeList { type = "Animal" });
            lister.Add(new TypeList { type = "Elderly" });
            return lister;
        }

    }
}