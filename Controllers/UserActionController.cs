using CharityApplication.Database;
using CharityApplication.Models;
using CharityApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        
        
        public ActionResult Index()
        {
            var model = new UserIndexViewModel
            {
                causes = causeContext.Collection().Where(x => x.isactive).ToList()
            };
            var tempMap= new Dictionary<int, string>();
            var tempList = organizationContext.Collection().ToList();
            foreach(var t in tempList)
            {
                tempMap.Add(t.Id, t.name);
            }
            model.orgMap = tempMap;
            model.row = model.causes.Count / 3;
            if (model.causes.Count % 3 != 0)
            {
                model.row += 1;
            }
            model.cols = model.causes.Count;
            return View(model);
        }
        [HttpGet]
        public ActionResult ViewOrg(int orgId)
        {
            var temp = new OrgViewModel();
            temp.org = organizationContext.Collection().FirstOrDefault(x=>x.Id==orgId);
            temp.causes = causeContext.Collection().Where(x => x.orgId == orgId).ToList();
            temp.cols = temp.causes.Count();
            temp.row = temp.cols/3;
            if (temp.cols % 3 != 0)
            {
                temp.row += 1;
            }
            temp.fundsCollected = donationContext.Collection().Where(x => x.orgId == orgId).ToList().Sum(x => x.amount);
            temp.totalUsers = donationContext.Collection().Where(x => x.orgId == orgId).Count();
            return View(temp);
        } 

        public ActionResult ViewCause(int causeId)
        {
            var model = new CauseViewModel
            {
                Cause = causeContext.Collection().FirstOrDefault(x => x.Id == causeId)
            };
            model.Organization = organizationContext.Collection().FirstOrDefault(x => x.Id == model.Cause.orgId) ;
            return View(model);
        }

        public ActionResult History()
        {
            Donations = donationContext.Collection().Where(x => x.userId == General.userId).ToList();
            var temp = organizationContext.Collection().ToList();
            var temp2 = causeContext.Collection().ToList();
            List<UserViewModel> donateList = new List<UserViewModel>();
            foreach (var d in Donations)
            {
                donateList.Add(new UserViewModel
                {
                    userId = d.userId,
                    organization = organizationContext.Collection().FirstOrDefault(x => x.Id == d.orgId).name,
                    orgId = d.orgId,
                    amount = d.amount,
                    causeId = d.causeId,
                    cause = causeContext.Collection().FirstOrDefault(x => x.Id == d.causeId).name,
                    time=d.date.ToShortDateString(),
                    transactionHash=d.transactionhash
                });
            }
            return View(donateList);
        }
        public ActionResult Donate(int causeId,int orgId,int userId)
        {
            var model = new DonationViewModel();
            model.causeId = causeId;
            model.causeName = causeContext.Find(causeId).name;
            model.orgId = orgId;
            model.orgName = organizationContext.Find(orgId).name;
            model.userId = userId;
            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> Donate(DonationViewModel model) {
            var temp = new donation();
            temp.Id = model.Id;
            temp.orgId = model.orgId;
            temp.userId = General.userId;
            temp.causeId = model.causeId;
            temp.amount = model.amount;
            temp.date = DateTime.Today;
            temp.transactionhash = await Smart.donate(temp.amount,temp.userId,temp.orgId,temp.causeId);
            var x = causeContext.Find(model.causeId);
            x.collected += model.amount;
            causeContext.Insert(x);
            causeContext.Save();
            donationContext.Insert(temp);
            donationContext.Save();
            return RedirectToAction("History","UserAction");
        }
    }
}