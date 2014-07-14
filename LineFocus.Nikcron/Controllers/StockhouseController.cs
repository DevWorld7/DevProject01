using LineFocus.Nikcron.Models;
using Nickron.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LineFocus.Nikcron.Controllers
{
    public class StockhouseController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Header = "Stockhit";
            ViewBag.Caption = "Listing";
            return View();
        }
        [HttpGet]
        public JsonResult GetStockhouses()
        {
            ApplicationDBContext db = new ApplicationDBContext();
            var companies = from c in db.Offices.OfType<Company>().ToList()
                            join s in db.Offices.OfType<Stockhouse>().ToList() on c.Id equals s.CompanyId
                            select new
                            {
                                CompanyId = c.Id,
                                CompanyName = c.Name,
                                Id = s.Id,
                                Name = s.Name,
                                ContactPerson = s.ContactPerson,
                                AddressLine1 = s.Address.Address1,
                                AddressLine2 = s.Address.Address2,
                                AddressCity = s.Address.City,
                                AddressState = s.Address.State,
                                AddressZip = s.Address.Zip,
                                Mobile = string.Join(" ", s.Contact1.Mobile, s.Contact2.Mobile),
                                Phone = string.Join(" ", s.Contact1.Phone, s.Contact2.Mobile),
                                Email = string.Join(" ", s.Contact1.Email, s.Contact2.Email),
                                Web = string.Join(" ", s.Contact1.Website, s.Contact2.Website)
                            };
            JsonResult result = new JsonResult();
            result.Data = companies;
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;
        }
        [HttpGet]
        public ActionResult Maintenance(Int32? StockhouseId)
        {
            Lookup Lookup_Companies = new Lookup();
            Lookup Lookup_States = new Lookup();
            Lookup Lookup_Countries = new Lookup();
            Lookup Lookup_Zones = new Lookup();

            ApplicationDBContext db = new ApplicationDBContext();

            var query1 = from records in db.States
                         select new LookupItem() { Id = records.Id, Name = records.Name };
            Lookup_States.Items = query1.ToList();

            var query2 = from records in db.Countries
                         select new LookupItem() { Id = records.Id, Name = records.Name };
            Lookup_Countries.Items = query2.ToList();

            var query3 = from records in db.Offices.OfType<Company>()
                         select new LookupItem() { Id = records.Id, Name = records.Name };
            Lookup_Companies.Items = query3.ToList();

            var query4 = from records in db.Zones
                         select new LookupItem() { Id = records.Id, Name = records.Name};
            Lookup_Zones.Items = query4.ToList();

            ViewBag.Header = "Stockhouse";
            ViewBag.Companies = Lookup_Companies;
            ViewBag.States = Lookup_States;
            ViewBag.Countries = Lookup_Countries;
            ViewBag.Zones = Lookup_Zones;

            if (StockhouseId.HasValue)
            {
                ViewBag.StockhouseId = StockhouseId;
                ViewBag.Caption = "Edit";
                
                Stockhouse stockhouse = db.Offices.OfType<Stockhouse>().Where(s => s.Id == StockhouseId).FirstOrDefault();
                return View(stockhouse);
            }
            else
            {
                ViewBag.StockhouseId = 0;
                ViewBag.Caption = "New";
                return View(new Stockhouse());
            }
        }
        [HttpPost]
        public ActionResult Maintenance(FormCollection formCollection)
        {
            ApplicationDBContext db = new ApplicationDBContext();
            Stockhouse stockhouse;
            Int32 StockhouseId = 0;
            Int32.TryParse(formCollection["Id"],out StockhouseId);
            if (StockhouseId == 0)
                stockhouse = new Stockhouse();
            else
                stockhouse = db.Offices.OfType<Stockhouse>().Where(s => s.Id == StockhouseId).FirstOrDefault();

            stockhouse.CompanyId = Int32.Parse(formCollection["Company"]);
            stockhouse.Name = formCollection["Stockhouse"];
            if (!string.IsNullOrEmpty(formCollection["Joindate"]))
                stockhouse.JoiningDate = DateTime.Parse(formCollection["Joindate"]);
            stockhouse.RecommendationFrom = formCollection["Recommendedby"];
            //stockhouse.ZoneId = Int32.Parse(formCollection["Zone"]);
            stockhouse.ContactPerson = formCollection["ContactPerson"];
            stockhouse.Address.Address1 = formCollection["Address1"];
            stockhouse.Address.Address2 = formCollection["Address2"];
            stockhouse.Address.City = formCollection["City"];
            stockhouse.Address.Zip = formCollection["Zip"];
            stockhouse.Address.State = formCollection["State"];
            stockhouse.Address.Country = formCollection["Country "];
            stockhouse.Contact1.Mobile = formCollection["Mobilenumber1"];
            stockhouse.Contact2.Mobile = formCollection["Mobilenumber2"];
            stockhouse.Contact1.Phone = formCollection["Phonenumber1"];
            stockhouse.Contact2.Phone = formCollection["Phonenumber2"];
            stockhouse.Contact1.Email = formCollection["Email"];
            stockhouse.Location = formCollection["Location"];
            int ff = 0;
            int.TryParse(formCollection["StrengthFF"], out ff);
            stockhouse.StrengthOfFieldForce = ff;
            stockhouse.PeakSalesPeriod = formCollection["Peeksaleperiod"];
            stockhouse.PopularFestivalFairs = formCollection["Popularfestivals"];
            stockhouse.ApprovalComments = formCollection["Commands"];
            //stockhouse.Username = formCollection["Username"];
            //stockhouse.Pwd = formCollection["Password"];
            if(StockhouseId == 0)
                db.Offices.AddObject(stockhouse);
            db.SaveChanges();
            return View("Index");
        }
    }
}
