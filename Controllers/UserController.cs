using CharityApplication.Database;
using CharityApplication.Models;
using CharityApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;

namespace CharityApplication.Controllers
{
    public class UserController : Controller
    {
        SQLRepository<user> userContext = new SQLRepository<user>(new DataContext());
        List<user> Users;
        public UserController()
        {
            Users = userContext.Collection().ToList();
        }

        // GET: User
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid && model != null)
            {
                if (Users.Exists(x => x.email == model.email && x.password == model.password))
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return RedirectToAction("Index", "Error", new { error = "User does not exist" });
                }
            }
            else
            {
                return View(model);

            }
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(user usr)
        {
            if (!ModelState.IsValid && usr!=null)
            {
                return View(usr);
            }
            else
            {
                usr.hash = string.Concat(usr.fname, usr.lname).GetHashCode();
                userContext.Insert(usr);
                userContext.Save();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Index()
        {
            return View();
        }

    } 
}