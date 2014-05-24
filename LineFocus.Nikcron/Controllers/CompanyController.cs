using Nickron.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LineFocus.Nikcron.Controllers
{
    public class CompanyController : Controller
    {
        //
        // GET: /Company/

        public ActionResult Index()
        {
            ApplicationDBContext db = new ApplicationDBContext();
            Company company = new Company();
            return View(db.Offices.OfType<Company>().ToList().Where(c=>c.Status.IsDeleted != true));
        }

        [HttpGet]
        public ActionResult Maintenance(Int32? CompanyId)
        {
            if (CompanyId.HasValue)
            {
                ViewBag.CompanyId = CompanyId;
                ApplicationDBContext db = new ApplicationDBContext();
                Company Company = db.Offices.OfType<Company>().Where(c => c.Id == CompanyId).ToList().FirstOrDefault();
                return View(Company);
            }
            else
            {
                ViewBag.CompanyId = "0";
                return View(new Company());
            }
        }

        [HttpPost]
        public ActionResult Maintenance(FormCollection formCollection)
        {
            ApplicationDBContext db = new ApplicationDBContext();
            if (formCollection["CompanyId"] == "0")
            {
                Company Company = new Company();
                Company.Name = formCollection["CompanyName"];
                Company.ContactPerson = formCollection["ContactPerson"];
                Company.Address.Address1 = formCollection["Address1"];
                Company.Address.Address2 = formCollection["Address2"];
                Company.Address.City = formCollection["City"];
                Company.Address.Zip = formCollection["Zip"];
                db.Offices.AddObject(Company);
            }
            else {
                int CompanyId = int.Parse(formCollection["CompanyId"]);
                Company Company = db.Offices.OfType<Company>().Where(c => c.Id == CompanyId).FirstOrDefault();
                Company.Name = formCollection["CompanyName"];
                Company.ContactPerson = formCollection["ContactPerson"];
                Company.Address.Address1 = formCollection["Address1"];
                Company.Address.Address2 = formCollection["Address2"];
                Company.Address.City = formCollection["City"];
                Company.Address.Zip = formCollection["Zip"];
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(Int32? CompanyId)
        {
            if(CompanyId.HasValue)
            {
                ApplicationDBContext db = new ApplicationDBContext();
                Office Office = db.Offices.OfType<Company>().Where(c=>c.Id == CompanyId).FirstOrDefault();
                db.DeleteObject(Office);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

    }
}
