using CharityApplication.Database;
using CharityApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CharityApplication.Controllers
{
    public class HomeController : Controller
    {
        //SQLRepository<user> userContext=new SQLRepository<user>(new DataContext());

        public ActionResult Index()
        {
            return View() ;
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}