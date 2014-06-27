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
    }
}
