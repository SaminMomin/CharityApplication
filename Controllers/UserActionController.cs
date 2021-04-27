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
            if (General.userLoginStatus == true) {
            General.orgLoginStatus = false;
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
            model.row = model.causes.Count / 2;
            if (model.causes.Count % 2 != 0)
            {
                model.row += 1;
            }
            model.cols = model.causes.Count;
            return View(model);
            }
            else { if (General.orgLoginStatus == true) {
                    General.orgLoginStatus = false;
                    General.orgName = "";
                    General.orgId = -1;
                    General.orgTx = "";
                }
                return RedirectToAction ("Login", "User"); }
        }
        [HttpGet]
        public ActionResult ViewOrg(int orgId)
        {
                var temp = new OrgViewModel();
            temp.org = organizationContext.Collection().FirstOrDefault(x=>x.Id==orgId);
            temp.activeCauses= causeContext.Collection().Where(x => x.orgId == orgId && x.isactive==true).ToList();
            temp.completedCauses= causeContext.Collection().Where(x => x.orgId == orgId && x.isactive==false).ToList();
            temp.cols = temp.activeCauses.Count();
            temp.row = temp.cols/3;
            if (temp.cols % 3 != 0)
            {
                temp.row += 1;
            }

            temp.ccols = temp.completedCauses.Count();
            temp.crow = temp.ccols / 3;
            if (temp.ccols % 3 != 0)
            {
                temp.crow += 1;
            }
            temp.totalCauses = temp.cols + temp.ccols;
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
            if (General.userLoginStatus == true) {
                General.orgLoginStatus = false;
                Donations = donationContext.Collection().Where(x => x.userId == General.userId).OrderByDescending(x=>x.date).ToList();
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
            else {
                if (General.orgLoginStatus == true)
                {
                    General.orgLoginStatus = false;
                    General.orgName = "";
                    General.orgId = -1;
                    General.orgTx = "";
                }
                return RedirectToAction("Login", "User"); }
        }
        public ActionResult Donate(int causeId,int orgId,int userId)
        {
            if (General.userLoginStatus == true) {
                General.orgLoginStatus = false;

                var model = new DonationViewModel();
            model.causeId = causeId;
            model.causeName = causeContext.Find(causeId).name;
            model.orgId = orgId;
            model.orgName = organizationContext.Find(orgId).name;
            model.userId = userId;
            return View(model);
            }
            else {
                if (General.orgLoginStatus == true)
                {
                    General.orgLoginStatus = false;
                    General.orgName = "";
                    General.orgId = -1;
                    General.orgTx = "";
                }
                return RedirectToAction("Login", "User"); }
        }
        [HttpPost]
        public async Task<ActionResult> Donate(DonationViewModel model)
        {
            if (General.userLoginStatus == true)
            {
                General.orgLoginStatus = false;

                var temp = new donation();
                temp.Id = model.Id;
                temp.orgId = model.orgId;
                temp.userId = General.userId;
                temp.causeId = model.causeId;
                temp.amount = model.amount;
                temp.date = DateTime.Today;
                temp.transactionhash = await Smart2.donate(temp.amount, temp.userId, temp.orgId, temp.causeId);
                var x = causeContext.Find(model.causeId);
                if (x.isactive == true)
                {
                    if (x.goal > x.collected)
                    {
                        x.collected += model.amount;
                        if (x.goal < x.collected)
                        {
                            x.isactive = false;
                        }
                    }
                    else
                    {
                        x.isactive = false;
                    }
                }

                causeContext.Update(x);
                causeContext.Save();
                donationContext.Insert(temp);
                donationContext.Save();
                return RedirectToAction("History", "UserAction");
            }
            else
            {
                if (General.orgLoginStatus == true)
                {
                    General.orgLoginStatus = false;
                    General.orgName = "";
                    General.orgId = -1;
                    General.orgTx = "";
                }
                return RedirectToAction("Login", "User");
            }
        }
}
}