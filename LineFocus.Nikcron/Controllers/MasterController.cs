using LineFocus.Nikcron.Models;
using Nickron.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LineFocus.Nikcron.Controllers
{
    public class MasterController : Controller
    {
        public ActionResult Zone()
        {
            return View();
        }

        public ContentResult AddEditLookup(String LookupType, Int32? Id, String Name)
        {
            ApplicationDBContext db = new ApplicationDBContext();
            if (Id.HasValue)
            {
                switch (LookupType)
                { 
                    case "Zone":
                        Zone Zone = db.Zones.Where(z => z.Id == Id.Value).FirstOrDefault();
                        Zone.Id = Id.Value;
                        Zone.Name = Name;
                        db.SaveChanges();
                        break;
                    case "ProductType":
                        ProductType ProductType = db.ProductTypes.Where(z => z.Id == Id.Value).FirstOrDefault();
                        ProductType.Id = Id.Value;
                        ProductType.Name = Name;
                        db.SaveChanges();
                        break;

                    case "ServiceType":
                        ServiceType ServiceType = db.ServiceTypes.Where(z => z.Id == Id.Value).FirstOrDefault();
                        ServiceType.Id = Id.Value;
                        ServiceType.Name = Name;
                        db.SaveChanges();
                        break;

                    case "ReturnType":
                        ReturnType ReturnType = db.ReturnTypes.Where(z => z.Id == Id.Value).FirstOrDefault();
                        ReturnType.Id = Id.Value;
                        ReturnType.Name = Name;
                        db.SaveChanges();
                        break;
                }
                
            }
            else
            {
                switch (LookupType)
                {
                    case "Zone":
                        Zone Zone = new Zone();
                        Zone.Name = Name;
                        db.Zones.AddObject(Zone);
                        db.SaveChanges();
                        break;
                    case "ProductType":
                        ProductType ProductType = new ProductType();
                        ProductType.Name = Name;
                        db.ProductTypes.AddObject(ProductType);
                        db.SaveChanges();
                        break;
                    case "ServiceType":
                        ServiceType ServiceType = new ServiceType();
                        ServiceType.Name = Name;
                        db.ServiceTypes.AddObject(ServiceType);
                        db.SaveChanges();
                        break;
                    case "ReturnType":
                        ReturnType ReturnType = new ReturnType();
                        ReturnType.Name = Name;
                        db.ReturnTypes.AddObject(ReturnType);
                        db.SaveChanges();
                        break;
                }
                
            }
            ContentResult Result = new ContentResult();
            Result.Content = "Success";
            return Result;
        }

        public ActionResult LookupList(String LookupType)
        {
            ApplicationDBContext db = new ApplicationDBContext();
            Lookup Lookup = new Lookup();
            switch (LookupType)
            {
                case "Zone":
                    var query1 = from records in db.Zones
                                select new LookupItem() { Id = records.Id, Name = records.Name };
                    Lookup.Items = query1.ToList();
                    break;
                case "Company":
                    var query2 = from records in db.Offices.OfType<Company>()
                                select new LookupItem() { Id = records.Id, Name = records.Name };
                    Lookup.Items = query2.ToList();
                    break;
                case "ProductType":
                    var query3 = from records in db.ProductTypes
                                select new LookupItem() { Id = records.Id, Name = records.Name };
                    Lookup.Items = query3.ToList();
                    break;
                case "ServiceType":
                    var query4 = from records in db.ServiceTypes
                                select new LookupItem() { Id = records.Id, Name = records.Name };
                    Lookup.Items = query4.ToList();
                    break;
                case "ReturnType":
                    var query5 = from records in db.ReturnTypes
                                select new LookupItem() { Id = records.Id, Name = records.Name };
                    Lookup.Items = query5.ToList();
                    break;
                case "Manufacture":
                    var query6 = from records in db.Manufactures
                                select new LookupItem() { Id = records.Id, Name = records.Name };
                    Lookup.Items = query6.ToList();
                    break;
                case "Stockhouse":
                    var query7 = from records in db.Offices.OfType<Stockhouse>()
                                select new LookupItem() { Id = records.Id, Name = records.Name };
                    Lookup.Items = query7.ToList();
                    break;
            }
            return View(Lookup);
        }

        public JsonResult GetLookups(String LookupType)
        {
            ApplicationDBContext db = new ApplicationDBContext();
            JsonResult JsonData = new JsonResult();
            switch (LookupType)
            { 
                case "Zone":
                    JsonData.Data = db.Zones.Select(n => new { n.Id, n.Name }).ToList();
                    break;
                case "Company":
                    JsonData.Data = db.Offices.OfType<Company>().Select(n => new { n.Id, n.Name }).ToList();
                    break;
                case "ProductType":
                    JsonData.Data = db.ProductTypes.Select(n => new { n.Id, n.Name }).ToList();
                    break;
                case "ServiceType":
                    JsonData.Data = db.ServiceTypes.Select(n => new { n.Id, n.Name }).ToList();
                    break;
                case "ReturnType":
                    JsonData.Data = db.ReturnTypes.Select(n => new { n.Id, n.Name }).ToList();
                    break;
                case "Manufacture":
                    JsonData.Data = db.Manufactures.Select(n => new { n.Id, n.Name }).ToList();
                    break;
                case "Stockhouse":
                    JsonData.Data = db.Offices.OfType<Stockhouse>().Select(n => new { n.Id, n.Name }).ToList();
                    break;
            }
            JsonData.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return JsonData;
        }

        public JsonResult GetCities(String Name)
        {
            ApplicationDBContext db = new ApplicationDBContext();
            JsonResult Result = new JsonResult();
            Result.Data = db.Cities.Where(c => c.Name.StartsWith(Name)).Take(20).ToList().Select(n => new { n.Id, n.Name });
            Result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return Result;
        }

        public JsonResult GetStateCountry(Int32 CityId)
        {
            ApplicationDBContext db = new ApplicationDBContext();
            JsonResult Result = new JsonResult();
            var data = from s in db.States
                       join c in db.Countries on s.CountryId equals c.Id
                       join ct in db.Cities on s.Id equals ct.StateId
                       where ct.Id == CityId
                       select new
                       {
                           CountryId = c.Id,
                           CountryName = c.Name,
                           StateId = s.Id,
                           StateName = s.Name
                       };
            Result.Data = data;
            return Result;
        }

        public JsonResult GetStates(String Country)
        {
            ApplicationDBContext db = new ApplicationDBContext();
            JsonResult Result = new JsonResult();
            var data = from s in db.States
                       join c in db.Countries on s.CountryId equals c.Id
                       where c.Name == Country
                       select new
                       {
                           s.Id,
                           s.Name
                       };
            Result.Data = data;
            Result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return Result;
        }

        public JsonResult GetCountries()
        {
            ApplicationDBContext db = new ApplicationDBContext();
            var data = db.Countries.Select(n => new { n.Id, n.Name });
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetStockhouse(Int32 Zoneid)
        {
            ApplicationDBContext db = new ApplicationDBContext();
            JsonResult Result = new JsonResult();
            var data = from o in db.Offices
                       join s in db.Offices.OfType<Stockhouse>() on o.Id equals s.Id
                       select new
                       {
                           id = o.Id,
                           Name = o.Name
                       };
            Result.Data = data;
            return Result;
        }



        public ActionResult ServiceTypeMaintenance()
        {
            return View();
        }
        public ActionResult ProductTypeMaintenance()
        {
            return View();
        }

        public ActionResult ManufactureMaintenance()
        {
            return View();
        }
        public ActionResult ZoneMaintenance()
        {
            return View();
        }
        public ActionResult CountryMaintenance()
        {
            return View();
        }
        public ActionResult StateMaintenance()
        {
            return View();
        }
        public ActionResult CityMaintenance()
        {
            return View();
        }


    }
}
