using Nickron.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LineFocus.Nikcron.Controllers
{
    public class DealerController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public JsonResult GetDealers()
        {
            throw new NotImplementedException();            
        }
        [HttpGet]
        public ActionResult Maintenance(Int32? DealerId)
        {
            if (DealerId.HasValue)
            {
                ApplicationDBContext db = new ApplicationDBContext();
                Dealers Dealer = db.Offices.OfType<Dealers>().Where(d => d.Id == DealerId).FirstOrDefault();
                ViewBag.DealerId = DealerId;
                return View(Dealer);
            }
            else
            {
                ViewBag.DealerId = "0";
                return View(new Dealers());                    
            }
        }
        [HttpPost]
        public ActionResult Maintenance(FormCollection formCollection)
        {
            ApplicationDBContext db = new ApplicationDBContext();
            if (formCollection["DealerId"] == "0")
            {
                Dealers Dealers = new Dealers();
                //Dealers.JoinDate = formCollection["JoinDate"];
                //Dealers.RecommendedBy = formCollection["RecommendedBy"];
                Dealers.DistributorId = Int32.Parse(formCollection["Distributor"]); // Send always 1 for now.. before insert 1 record with id 1 in zone table

                Dealers.ContactPerson = formCollection["Firstname"];
                //Dealers.Lastname = formCollection["Lastname"];
                Dealers.Name = formCollection["Companyname"];
                Dealers.Address.Address1 = formCollection["Address1"];
                Dealers.Address.Address2 = formCollection["Address2"];
                Dealers.Address.City = formCollection["City"];
                Dealers.Address.Zip = formCollection["Zip"];
                Dealers.Address.State = formCollection["State"];
                Dealers.Address.Country = formCollection["Country "];
                Dealers.Contact1.Mobile = formCollection["Mobilenumber1"];
                Dealers.Contact2.Mobile = formCollection["Mobilenumber2"];
                Dealers.Contact1.Phone = formCollection["Phonenumber1"];
                Dealers.Contact2.Phone = formCollection["Phonenumber2"];
                Dealers.Contact1.Email = formCollection["Email"];
                Dealers.Location = formCollection["Location"];
                //Dealers.StrengthFF = formCollection["StrengthFF"];
                //Dealers.Peeksaleperiod = formCollection["Peeksaleperiod"];
                //Dealers.Popularfestivals = formCollection["Popularfestivals"];
                //Dealers.Commands = formCollection["Commands"];
                //Dealers.Username = formCollection["Username"];
                //Dealers.Password = formCollection["Password"];
                db.Offices.AddObject(Dealers);

                return View("Index");
            }
            else
            {
                return View();
            }
        }
    }
}
