using Nickron.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LineFocus.Nikcron.Controllers
{
    public class DistributorController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Header = "Distributor";
            ViewBag.Caption = "Listing";
            return View();
        }

        [HttpGet]
        public JsonResult GetDistributors()
        {
            ApplicationDBContext db = new ApplicationDBContext();
            var companies = from c in db.Offices.OfType<Company>().ToList()
                            join s in db.Offices.OfType<Stockhouse>().ToList() on c.Id equals s.CompanyId
                            join d in db.Offices.OfType<Distributor>().ToList() on s.Id equals d.StockhouseId
                            select new
                            {
                                CompanyId = c.Id,
                                CompanyName = c.Name,
                                StockhouseId = s.Id,
                                StockhouseName = s.Name,
                                Id = d.Id,
                                Name = d.Name,
                                ContactPerson = d.ContactPerson,
                                AddressLine1 = d.Address.Address1,
                                AddressLine2 = d.Address.Address2,
                                AddressCity = d.Address.City,
                                AddressState = d.Address.State,
                                AddressZip = d.Address.Zip,
                                Mobile = string.Join(" ", d.Contact1.Mobile, d.Contact2.Mobile),
                                Phone = string.Join(" ", d.Contact1.Phone, d.Contact2.Mobile),
                                Email = string.Join(" ", d.Contact1.Email, d.Contact2.Email),
                                Web = string.Join(" ", d.Contact1.Website, d.Contact2.Website)
                            };
            JsonResult result = new JsonResult();
            result.Data = companies;
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;
        }

        [HttpGet]
        public ActionResult Maintenance(Int32? DistributorId)
        {
            ViewBag.Header = "Distributor";
            if (DistributorId.HasValue)
            {
                ViewBag.StockhouseId = DistributorId;
                ViewBag.Caption = "Edit";
                ApplicationDBContext db = new ApplicationDBContext();
                Distributor distributor = db.Offices.OfType<Distributor>().Where(s => s.Id == DistributorId).FirstOrDefault();
                return View(distributor);
            }
            else
            {
                ViewBag.DistributorId = 0;
                ViewBag.Caption = "New";
                return View(new Distributor());
            }
        }
        [HttpPost]
        public ActionResult Maintenance(FormCollection formCollection)
        {
            ApplicationDBContext db = new ApplicationDBContext();
            Distributor distributor;
            Int32 DistributorId = 0;
            Int32.TryParse(formCollection["Id"], out DistributorId);
            if (DistributorId == 0)
                distributor = new Distributor();
            else
                distributor = db.Offices.OfType<Distributor>().Where(s => s.Id == DistributorId).FirstOrDefault();

            distributor.StockhouseId = Int32.Parse(formCollection["Stockhouse"]);
            distributor.Name = formCollection["ContactPerson"];
            if (!string.IsNullOrEmpty(formCollection["Joindate"]))
                distributor.JoiningDate = DateTime.Parse(formCollection["Joindate"]);
            distributor.RecommendationFrom = formCollection["Recommendedby"];
            distributor.ContactPerson = formCollection["ContactPerson"];
            distributor.Address.Address1 = formCollection["Address1"];
            distributor.Address.Address2 = formCollection["Address2"];
            distributor.Address.City = formCollection["City"];
            distributor.Address.Zip = formCollection["Zip"];
            distributor.Address.State = formCollection["State"];
            distributor.Address.Country = formCollection["Country "];
            distributor.Contact1.Mobile = formCollection["Mobilenumber1"];
            distributor.Contact2.Mobile = formCollection["Mobilenumber2"];
            distributor.Contact1.Phone = formCollection["Phonenumber1"];
            distributor.Contact2.Phone = formCollection["Phonenumber2"];
            distributor.Contact1.Email = formCollection["Email"];
            distributor.Location = formCollection["Location"];
            int ff = 0;
            int.TryParse(formCollection["StrengthFF"], out ff);
            distributor.StrengthOfFieldForce = ff;
            distributor.PeakSalesPeriod = formCollection["Peeksaleperiod"];
            distributor.PopularFestivalFairs = formCollection["Popularfestivals"];
            distributor.ApprovalComments = formCollection["Commands"];
            //stockhouse.Username = formCollection["Username"];
            //stockhouse.Pwd = formCollection["Password"];
            if (DistributorId == 0)
                db.Offices.AddObject(distributor);
            db.SaveChanges();
            return View("Index");
        }

    }
}
