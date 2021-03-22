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
        private SQLRepository<user> userContext = new SQLRepository<user>(new DataContext());
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
                if (Users.Exists(x => x.email == model.email && x.password.GetHashCode().ToString() == model.password.GetHashCode().ToString()))
                {
                    var usr= Users.FirstOrDefault(x => x.email == model.email);
                    General.userLoginStatus = true;
                    General.userId = usr.Id;
                    General.userName = usr.fname;
                    return RedirectToAction("Index", "UserAction",new { Id = usr.Id });
                }
                else
                {
                    return RedirectToAction("Index", "Error", new { error = "User does not exist", type=1});
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
            if (!ModelState.IsValid && usr == null)
            {
                return View(usr);
            }
            else if (Users.Exists(x => x.email == usr.email || x.contact == usr.contact)) {
                return RedirectToAction("Index", "Error", new { error="User already exists",type=2});
            }
            else
            {
                user temp = new user();
                temp.fname = usr.fname;
                temp.lname = usr.lname;
                temp.password = usr.password;
                temp.state = usr.state;
                temp.email = usr.email;
                temp.dob = usr.dob;
                temp.country = usr.country;
                temp.contact = usr.contact;
                temp.city = usr.city;
                temp.age = usr.age;
                temp.hash = string.Concat(usr.fname, usr.lname).GetHashCode() & 0xfffffff;
                userContext.Insert(temp);
                userContext.Save();
                Users.Add(usr);
                return RedirectToAction("Login","User");
            }
        }

        public ActionResult Edit(int Id)
        {
            return View(Users.FirstOrDefault(x => x.Id == Id));
         }
        
        [HttpPost]
        public ActionResult Edit(user usr)
        {
            if (!ModelState.IsValid && usr == null)
            {
                return View(usr);
            }
            else
            {
                var t = userContext.Find(General.userId);
                if (t != null)
                {
                    if (!ModelState.IsValid)
                    {
                        return View(usr);
                    }
                    else
                    {
                        t.Id = usr.Id;
                        t.fname = usr.fname;
                        t.lname = usr.lname;
                        t.password = usr.password;
                        t.state = usr.state;
                        t.email = usr.email;
                        t.dob = usr.dob;
                        t.country = usr.country;
                        t.contact = usr.contact;
                        t.city = usr.city;
                        t.age = usr.age;
                        t.hash = string.Concat(usr.fname, usr.lname).GetHashCode();
                        userContext.Save();
                        Users.Remove(Users.FirstOrDefault(x => x.Id == usr.Id));
                        Users.Add(usr);
                        return RedirectToAction("Index", "UserAction",new { usr.Id });
                    }
                }
                else
                {
                    return RedirectToAction("Index", "Error",new { error="User not found",type=1});
                }
                
            }
        }
public ActionResult Delete(int id)
        {
            return View(Users.FirstOrDefault(x => x.Id == id));
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(int Id)
        {
            var usr = userContext.Find(Id);
            if (usr != null)
            {
                userContext.Delete(Id);
                userContext.Save();
                Users.Remove(usr);
                General.userId= -1;
                General.orgLoginStatus = false;
                General.userLoginStatus = false;
                General.userName= "";
                return RedirectToAction("Login","User");
            }
            else
            {
                return RedirectToAction("Index", "Error", new { error = "User not found!",type=2 });
            }
        }

        public ActionResult Logout()
        {
            General.userLoginStatus = false;
            General.orgLoginStatus = false;
            General.userId = -1;
            General.userName = "";
            return RedirectToAction("Login","User");
        }


    } 
}