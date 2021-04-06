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
    public class HomeController : Controller
    {
        SQLRepository<user> userContext = new SQLRepository<user>(new DataContext());
        SQLRepository<donation> donationContext = new SQLRepository<donation>(new DataContext());
        SQLRepository<organization> organizationContext = new SQLRepository<organization>(new DataContext());
        SQLRepository<cause> causeContext = new SQLRepository<cause>(new DataContext());

        public ActionResult Index()
        {
            var model = new HomeViewModel();
            model.Causes = causeContext.Collection().OrderByDescending(x => x.collected).Take(6).ToList();
            model.Organizations = organizationContext.Collection().Take(6).ToList();
            model.organizationCount = model.Organizations.Count();
            model.causeCount = model.Causes.Count();
            model.userCount = userContext.Collection().Count();
            if (causeContext.Collection().Count() != 0) {
                model.donationCount = causeContext.Collection().Sum(x => x.collected);
            }
            else
            {
                model.donationCount = 0;
            }
            
            return View(model);
        }
    }
}