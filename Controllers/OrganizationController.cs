using CharityApplication.Database;
using CharityApplication.Models;
using CharityApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CharityApplication.Controllers
{
    public class OrganizationController : Controller
    {
        private SQLRepository<organization> organizationContext=new SQLRepository<organization>(new DataContext());
        List<organization> Organizations;

        public OrganizationController()
        {
            Organizations = organizationContext.Collection().ToList();
        }

        // GET: Organization
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid && model != null)
            {
                if (Organizations.Exists(x => x.email == model.email && x.password.GetHashCode().ToString() == model.password.GetHashCode().ToString()))
                {
                    var Org = Organizations.FirstOrDefault(x => x.email == model.email);
                    //General.userLoginStatus = true;
                    General.orgLoginStatus = true;
                    General.orgId = Org.Id;
                    General.orgName = Org.name;
                    General.orgTx = Org.transactionhash;
                    return RedirectToAction("Index", "OrganizationAction", new { Id = Org.Id });
                }
                else
                {
                    return RedirectToAction("Index", "Error", new { error = "Organization does not exist", type = 3 });
                }
            }
            else
            {
                return View(model);
            }
        }

        public ActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public async Task<ActionResult> Register(organization Org,HttpPostedFileBase[] file)
        {
            if (!ModelState.IsValid)
            {
                return View(Org);
            }
            else if (Organizations.Exists(x => x.email == Org.email || x.contact == Org.contact))
            {
                return RedirectToAction("Index", "Error", new { error = "Organization already exists", type = 4 });
            }
            else
            {
                organization temp = new organization();
                temp.Id = Org.Id;
                temp.name = Org.name;
                temp.password = Org.password;
                temp.state = Org.state;
                temp.email = Org.email;
                temp.regno = Org.regno;
                temp.country = Org.country;
                temp.contact = Org.contact;
                temp.city = Org.city;
                temp.street= Org.street;
                temp.hash = string.Concat(Org.name, Org.regno).GetHashCode() & 0xfffffff;
                temp.fcra = Org.fcra;
                temp.type = Org.type;
                temp.website = Org.website;
                temp.description = Org.description;
                temp.transactionhash = await Smart.regOrg(temp.name);
                if (file != null)
                {
                    temp.profilepic = string.Concat(temp.Id, Path.GetExtension(file[0].FileName));
                    temp.regcerti = Org.Id+Path.GetExtension(file[1].FileName);
                    file[0].SaveAs(Server.MapPath("//OrganizationImages//") + temp.profilepic);
                    file[1].SaveAs(Server.MapPath("//OrganizationCertificates//")+temp.regcerti);
                }
                organizationContext.Insert(temp);
                organizationContext.Save();
                Organizations.Add(Org);
                return RedirectToAction("Login", "Organization");
            }
        }
        public ActionResult Edit(int Id)
        {
            return View(organizationContext.Collection().FirstOrDefault(x=>x.Id==Id));
        }
        [HttpPost]
        public ActionResult Edit(organization Org,HttpPostedFileBase[] file)
        {
            var temp = organizationContext.Find(General.orgId);
            if (!ModelState.IsValid || Org == null)
            {
                return View(Org);
            }
            else
            {
                if (temp != null)
                {
                    temp.Id = Org.Id;
                    temp.name = Org.name;
                    temp.password = Org.password;
                    temp.state = Org.state;
                    temp.email = Org.email;
                    temp.regno = Org.regno;
                    temp.country = Org.country;
                    temp.contact = Org.contact;
                    temp.city = Org.city;
                    temp.street = Org.street;
                    temp.hash = string.Concat(Org.name, Org.regno).GetHashCode() & 0xfffffff;
                    temp.fcra = Org.fcra;
                    temp.type = Org.type;
                    temp.website = Org.website;
                    temp.description = Org.description;
                    if (file != null)
                    {
                        temp.profilepic = string.Concat(temp.Id, Path.GetExtension(file[0].FileName));
                        temp.regcerti = Org.Id + Path.GetExtension(file[1].FileName);
                        file[0].SaveAs(Server.MapPath("//OrganizationImages//") + temp.profilepic);
                        file[1].SaveAs(Server.MapPath("//OrganizationCertificates//") + temp.regcerti);
                    }
                    organizationContext.Update(temp);
                    organizationContext.Save();
                    Organizations.Remove(Organizations.FirstOrDefault(x => x.Id == General.orgId));
                    Organizations.Add(Org);
                    return RedirectToAction("Index", "OrganizationAction", new { Id = Org.Id });
                }
                else
                {
                    return RedirectToAction("Index", "Error", new { error = "Organization not found!", type = 3 }) ;
                }
            }
        }

        public ActionResult Delete(int Id)
        {
            //var org= Organizations.Find(x=>x.Id==Id);
            return View(organizationContext.Find(Id));
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(int Id)
        {
            var temp = organizationContext.Find(Id);
            if (temp != null)
            {
                organizationContext.Delete(Id);
                organizationContext.Save();
                Organizations.Remove(temp);
                General.orgId = -1;
                General.orgLoginStatus = false;
                General.userLoginStatus = false;
                General.orgName = "";
                General.orgTx = "";
                return RedirectToAction("Login","Organization");
            }
            else
            {
                    return RedirectToAction("Index", "Error", new { error = "Organization not found!", type = 3 });   
            }
        }

        public ActionResult Logout()
        {
            General.userLoginStatus = false;
            General.orgLoginStatus = false;
            General.orgName = "";
            General.orgId = -1;
            General.orgTx = "";
            return RedirectToAction("Login","Organization");
        }
    }

}