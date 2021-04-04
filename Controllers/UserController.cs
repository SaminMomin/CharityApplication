using CharityApplication.Database;
using CharityApplication.Models;
using CharityApplication.ViewModels;
using Nethereum.Hex.HexTypes;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;

namespace CharityApplication.Controllers
{
    public class UserController : Controller
    {
        private SQLRepository<user> userContext = new SQLRepository<user>(new DataContext());
        List<user> Users;
        Smart contract = new Smart();
        //private string privateKey;
        //private Account account;
        //private Web3 web3;
        //private string abi;
        //private Nethereum.Contracts.Contract contract;
        //private HexBigInteger x = new HexBigInteger("1");
        //public string TransactionHash { get; set; }

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
                    General.userTx = usr.transactionhash;
                    return RedirectToAction("Index", "UserAction");
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
        public async Task<ActionResult> Register(user usr,HttpPostedFileBase file)
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
                if (file != null)
                {
                    temp.profilepic = string.Concat(temp.Id,Path.GetExtension(file.FileName));
                    file.SaveAs(Server.MapPath("//UserImages//"+temp.profilepic));
                }
                temp.hash = string.Concat(usr.fname, usr.lname).GetHashCode() & 0xfffffff;
                temp.transactionhash = await Smart2.regFunc(usr.Id,usr.fname);
                userContext.Insert(temp);
                userContext.Save();
                Users.Add(usr);
                return RedirectToAction("Login","User");
            }
        }

        public ActionResult Edit(int Id)
        {
            if (General.userLoginStatus == true) {
                General.orgLoginStatus = false;

                return View(userContext.Collection().FirstOrDefault(x => x.Id == Id));
            }
            else {
                if (General.orgLoginStatus == true)
                {
                    General.orgLoginStatus = false;
                    General.orgName = "";
                    General.orgId = -1;
                    General.orgTx = "";
                }
                return RedirectToAction("Login", "User"); }
        }
        
        [HttpPost]
        public ActionResult Edit(user usr,HttpPostedFileBase file)
        {
            if (General.userLoginStatus == true) {
                General.orgLoginStatus = false;

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
                        if (file != null)
                        {
                            t.profilepic = string.Concat(t.Id, Path.GetExtension(file.FileName));
                            file.SaveAs(Server.MapPath("//UserImages//" + t.profilepic));
                        }
                        t.hash = string.Concat(usr.fname, usr.lname).GetHashCode();
                        userContext.Save();
                        Users.Remove(Users.FirstOrDefault(x => x.Id == usr.Id));
                        Users.Add(usr);
                        return RedirectToAction("Index", "UserAction");
                    }
                }
                else
                {
                    return RedirectToAction("Index", "Error",new { error="User not found",type=1});
                }
            }
            }
            else {
                if (General.orgLoginStatus == true)
                {
                    General.orgLoginStatus = false;
                    General.orgName = "";
                    General.orgId = -1;
                    General.orgTx = "";
                }
                return RedirectToAction("Login", "User"); }
        }
public ActionResult Delete(int id)
        {
            if (General.userLoginStatus == true) {
                General.orgLoginStatus = false;

                return View(Users.FirstOrDefault(x => x.Id == id));
            }
            else {
                if (General.orgLoginStatus == true)
                {
                    General.orgLoginStatus = false;
                    General.orgName = "";
                    General.orgId = -1;
                    General.orgTx = "";
                }
                return RedirectToAction("Login", "User"); }
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(int Id)
        {
            General.orgLoginStatus = false;
            if (General.userLoginStatus == true) { 
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
            else {
                if (General.orgLoginStatus == true)
                {
                    General.orgLoginStatus = false;
                    General.orgName = "";
                    General.orgId = -1;
                    General.orgTx = "";
                }
                return RedirectToAction("Login", "User"); }
        }

        public ActionResult Logout()
        {
            General.userLoginStatus = false;
            General.orgLoginStatus = false;
            General.userId = -1;
            General.userName = "";
            General.userTx = "";
            return RedirectToAction("Index","Home");
        }

        public ActionResult Reset()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Reset(string email) 
        {
            var usr = userContext.Collection().ToList().FirstOrDefault(x=>x.email==email);
            if (usr != null)
            {
                var x = await Email.Execute(email, string.Concat(usr.fname, " ", usr.lname), usr.password);
                if (x == true) { General.useremailStatus = true; return RedirectToAction("Login", "User"); } else { return RedirectToAction("Index", "Error", new { error = "Failed to send email. Try again.", type = 2 }); }
            }
            else { return RedirectToAction("Index", "Error", new { error = "User does not exist", type = 1 }); }
        }
    } 
}