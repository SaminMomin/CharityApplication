using CharityApplication.Database;
using CharityApplication.Models;
using CharityApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CharityApplication.Controllers
{
    public class UserActionController : Controller
    {
        // GET: UserAction
        SQLRepository<donation> donationContext = new SQLRepository<donation>(new DataContext());
        SQLRepository<cause> causeContext = new SQLRepository<cause>(new DataContext());
        SQLRepository<organization> organizationContext = new SQLRepository<organization>(new DataContext());

        List<donation> Donations;
        List<cause> Causes;
        List<organization> Orgs;

        
        public ActionResult Index()
        {
            Donations = donationContext.Collection().Where(x => x.userId == General.userId).ToList();
            var temp = organizationContext.Collection().ToList();
            var temp2 = causeContext.Collection().ToList();
            foreach (var d in Donations)
            {
                if (temp.Exists(x => x.Id == d.orgId) && !Orgs.Exists(x => x.Id == d.orgId))
                {
                    Orgs.Add(temp.FirstOrDefault(x => x.Id == d.orgId));
                }

                if(temp2.Exists(x=>x.Id==d.causeId) && !Causes.Exists(x => x.Id == d.causeId))
                {
                    Causes.Add(temp2.FirstOrDefault(x => x.Id == d.causeId));
                }
            }
            List<UserViewModel> donateList = new List<UserViewModel>();
            foreach(var d in Donations)
            {
                donateList.Add(new UserViewModel
                {
                    userId = d.userId,
                    organization = Orgs.FirstOrDefault(x => x.Id == d.orgId).name,
                    orgId = d.orgId,
                    amount = d.amount,
                    causeId = d.causeId,
                    cause = Causes.FirstOrDefault(x => x.Id == d.causeId).name
                }) ;
            }
            return View(donateList);
        }
    }
}