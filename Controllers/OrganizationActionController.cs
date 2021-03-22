using CharityApplication.Database;
using CharityApplication.Models;
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
        List<cause> Causes;
        // GET: OrganizationAction
        public ActionResult Index()
        {
            if (General.orgId != -1)
            {
                Causes = causeContext.Collection().Where(x => x.orgId == General.orgId).ToList();
                return View(Causes);
            }
            else
            {
                return RedirectToAction("Index", "Error", new { error = "Organization not logged in. Please Log In first.", type = 4 });
            }
        }
    }
}