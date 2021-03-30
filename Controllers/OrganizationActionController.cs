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
    public class OrganizationActionController : Controller
    {
        SQLRepository<cause> causeContext = new SQLRepository<cause>(new DataContext());
        SQLRepository<organization> organizationContext = new SQLRepository<organization>(new DataContext());
        SQLRepository<donation> donationContext = new SQLRepository<donation>(new DataContext());
        
        List<cause> Causes;
        // GET: OrganizationAction
        public ActionResult Index()
        {
            var model = new OrgViewModel();
            if (General.orgId != -1)
            {
                model.activeCauses= causeContext.Collection().Where(x => x.orgId == General.orgId && x.isactive==true).ToList();
                model.completedCauses= causeContext.Collection().Where(x => x.orgId == General.orgId && x.isactive==false).ToList();
                model.org = organizationContext.Find(General.orgId);
                model.cols = model.activeCauses.Count();
                model.row = model.cols / 3;
                model.ccols = model.completedCauses.Count();
                model.crow = model.ccols / 3;
                
                if (model.cols % 3 != 0)
                {
                    model.row += 1;
                }

                if (model.ccols % 3 != 0)
                {
                    model.crow += 1;
                }
                model.totalCauses = model.cols + model.ccols;
                model.fundsCollected = donationContext.Collection().Where(x => x.orgId == General.orgId).ToList().Sum(x => x.amount);
                model.totalUsers = donationContext.Collection().Where(x => x.orgId == General.orgId).Count();
                return View(model);
            }
            else
            {
                return RedirectToAction("Index", "Error", new { error = "Organization not logged in. Please Log In first.", type = 4 });
            }
        }
    }
}