﻿using CharityApplication.Database;
using CharityApplication.Models;
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
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Register(cause model)
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
                    shortDescription=model.shortDescription,
                    longDescription = model.longDescription,
                    isactive = true,
                    type=model.type
                };
                temp.hash = String.Concat(temp.name, temp.longDescription,temp.shortDescription).GetHashCode();
                temp.transactionhash = await Smart.regCause(temp.orgId,temp.goal,temp.name);
                causeContext.Insert(temp);
                causeContext.Save();
                return RedirectToAction("Index","OrganizationAction");
            }
        }
    }
}