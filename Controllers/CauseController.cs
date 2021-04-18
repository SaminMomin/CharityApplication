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
    public class CauseController : Controller
    {
        // GET: Cause
        readonly SQLRepository<cause> causeContext = new SQLRepository<cause>(new DataContext());
        readonly SQLRepository<donation> donationContext = new SQLRepository<donation>(new DataContext());
        readonly SQLRepository<user> userContext = new SQLRepository<user>(new DataContext());

        public ActionResult Register()
        {
            if (General.orgLoginStatus == true) {
                General.userLoginStatus = false;

                return View();
            }
            else {
                if (General.userLoginStatus == true)
                {
                    General.userLoginStatus = false;
                    General.orgLoginStatus = false;
                    General.userId = -1;
                    General.userName = "";
                    General.userTx = "";
                }
                return RedirectToAction("Login", "Organization"); }
        }

        [HttpPost]
        public async Task<ActionResult> Register(cause model)
        {

            if (General.orgLoginStatus == true) {
                General.userLoginStatus = false;

                if (!ModelState.IsValid || model==null)
            {
                return View(model);
            }
            else
            {
                cause temp = new cause
                {
                    name = model.name,
                    goal = model.goal,
                    collected = 0,
                    orgId = General.orgId,
                    shortDescription=model.shortDescription,
                    longDescription = model.longDescription,
                    isactive = true,
                    type=model.type
                };
                temp.hash = String.Concat(temp.name, temp.longDescription,temp.shortDescription).GetHashCode();
                temp.transactionhash = await Smart2.regCause(temp.orgId,temp.Id,temp.goal,temp.name);
                causeContext.Insert(temp);
                causeContext.Save();
                return RedirectToAction("Index","OrganizationAction");
            }
            }
            else {
                if (General.userLoginStatus == true)
                {
                    General.userLoginStatus = false;
                    General.orgLoginStatus = false;
                    General.userId = -1;
                    General.userName = "";
                    General.userTx = "";
                }
                return RedirectToAction("Login", "Organization"); }
        }
        public ActionResult CloseCause(int causeId)
        {
            if (General.orgLoginStatus==true) {
                General.userLoginStatus = false;

                var model = causeContext.Find(causeId);
            model.isactive = false;
            causeContext.Update(model);
            causeContext.Save();
            return RedirectToAction("ManageCauses","Cause");
        } else {
                if (General.userLoginStatus == true)
                {
                    General.userLoginStatus = false;
                    General.orgLoginStatus = false;
                    General.userId = -1;
                    General.userName = "";
                    General.userTx = "";
                }
                return RedirectToAction("Login","Organization");
    }
}

        public ActionResult ManageCauses()
        {
            if (General.orgLoginStatus == true) {
                General.userLoginStatus = false;

                var model = causeContext.Collection().Where(x => x.orgId == General.orgId).ToList();
            return View(model);
            }
            else {
                if (General.userLoginStatus == true)
                {
                    General.userLoginStatus = false;
                    General.orgLoginStatus = false;
                    General.userId = -1;
                    General.userName = "";
                    General.userTx = "";
                }
                return RedirectToAction("Login", "Organization"); }
        }

        public ActionResult ViewDonations(int causeId)
        {
            if (General.orgLoginStatus == true) {
                General.userLoginStatus = false;

                var temp = donationContext.Collection().Where(x => x.causeId == causeId).OrderBy(x=>x.date).ToList();
            var model = new List<DonationHistoryVM>();
            var s = "bg-secondary";
           foreach(var t in temp)
            {
                model.Add(new DonationHistoryVM { userName = userContext.Find(t.userId).fname, amount = t.amount, date = t.date.ToShortDateString(),transactionHash=t.transactionhash,status=s });
                if (s == "bg-secondary") s = "bg-black";
                else s = "bg-secondary";
            }
            return View(model);
        } else {
                if (General.userLoginStatus == true)
                {
                    General.userLoginStatus = false;
                    General.orgLoginStatus = false;
                    General.userId = -1;
                    General.userName = "";
                    General.userTx = "";
                }
                return RedirectToAction("Login","Organization");
    }
}
    }
}