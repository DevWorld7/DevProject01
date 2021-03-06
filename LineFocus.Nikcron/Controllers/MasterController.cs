﻿using Nickron.Database;
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
                case "Stockhouse":
                    // JsonData.Data = db.Offices.OfType<Stockhouse>().Select(n => new { n.Id, n.Name }).ToList();

                    JsonData.Data = (from o in db.Offices
                                     join s in db.Offices.OfType<Stockhouse>() on o.Id equals s.Id
                                     select new
                                     {
                                         o.Id,
                                         o.Name
                                     }).ToList();

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
                       where s.ZoneId == Zoneid
                       select new
                       {
                           o.Id,
                           o.Name
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

        #region Zone Maintenane

        public ActionResult Index()
        {
            ApplicationDBContext db = new ApplicationDBContext();
            Zone Zone = new Zone();
            return View(db.Zones.OfType<Zone>().ToList().Where(c => c.Status.IsDeleted != true));
        }

        [HttpGet]
        public ActionResult ZoneMaintenance(Int32? Id)
        {
            ViewBag.Header = "Zone";
            if (Id.HasValue)
            {
                
                ViewBag.Caption = "Edit";
                ViewBag.Id = Id;
                ApplicationDBContext db = new ApplicationDBContext();
                Zone Zone = db.Zones.OfType<Zone>().Where(z => z.Id == Id).ToList().FirstOrDefault();
                return View(Zone);
            }
            else
            {
                ViewBag.Caption = "New";
                ViewBag.Id = "0";
                return View(new Zone());
            }
        }

        public ActionResult Delete(Int32? Id)
        {
            ViewBag.Header = "Zone";
            if (Id.HasValue)
            {
                ViewBag.Caption = "Delete";
                ViewBag.Id = Id;
                ApplicationDBContext db = new ApplicationDBContext();               
                Zone Zone = db.Zones.OfType<Zone>().Where(z => z.Id == Id).FirstOrDefault();
                db.DeleteObject(Zone);
                db.SaveChanges();
            }

            TempData["AlertMessage"] = "Data has been deleted succeessfully";         
            return RedirectToAction("Index");          
        }

        [HttpPost]
        public ActionResult ZoneMaintenance(FormCollection formCollection)
        {
            ApplicationDBContext db = new ApplicationDBContext();
            Zone Zone = new Zone();

            Int32 Id = 0;
            Int32.TryParse(formCollection["Id"], out Id);
            if (Id == 0)
                Zone = new Zone();
            else
                Zone = db.Zones.OfType<Zone>().Where(z => z.Id == Id).FirstOrDefault();

            Zone.Name = formCollection["Zone"];

            if (Id == 0)
            {
                db.Zones.AddObject(Zone);

                TempData["AlertMessage"] = "Data has been Added succeessfully";
            }
            else
            {
                TempData["AlertMessage"] = "Data has been Updated Successfully"; 
            }
            db.SaveChanges();

          
            return RedirectToAction("Index");
        }

        #endregion
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
