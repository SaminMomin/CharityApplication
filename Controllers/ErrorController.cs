using CharityApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CharityApplication.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult Index(string error,int type)
        {
            Error errors = new Error { error=error,type=type};
            return View(errors);
        }
    }
}