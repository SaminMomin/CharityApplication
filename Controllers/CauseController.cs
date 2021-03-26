using CharityApplication.Database;
using CharityApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CharityApplication.Controllers
{
    public class CauseController : Controller
    {
        // GET: Cause
        readonly SQLRepository<cause> causeContext = new SQLRepository<cause>(new DataContext());
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(cause model)
        {
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
                    collected = model.collected,
                    orgId = General.orgId,
                    description = model.description,
                    isactive = true
                };
                temp.hash = String.Concat(temp.name, temp.description).GetHashCode();
                temp.transactionhash = GetHashCode().ToString();
                causeContext.Insert(temp);
                causeContext.Save();
                return RedirectToAction("Index","OrganizationAction");
            }
        }
    }
}