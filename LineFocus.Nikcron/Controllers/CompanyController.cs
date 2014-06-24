using LineFocus.Nikcron.Models;
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
            ViewBag.Header = "Company";
            ViewBag.Caption = "Listing";
            ApplicationDBContext db = new ApplicationDBContext();
            Company company = new Company();
            return View();
        }

        [HttpGet]
        public ActionResult Maintenance(Int32? CompanyId)
        {
            ViewBag.Header = "Company";
            if (CompanyId.HasValue)
            {
                ViewBag.Caption = "Edit";
                ViewBag.CompanyId = CompanyId;
                ApplicationDBContext db = new ApplicationDBContext();
                Company Company = db.Offices.OfType<Company>().Where(c => c.Id == CompanyId).ToList().FirstOrDefault();
                return View(Company);
            }
            else
            {
                ViewBag.Caption = "New";
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

        public JsonResult GetCompanyWarehouse()
        {
            ApplicationDBContext db = new ApplicationDBContext();
            //var fg = db.Offices.OfType<Company>().Select()
            throw new NotImplementedException();
        }

        public JsonResult GetCompanies()
        {
            ApplicationDBContext db = new ApplicationDBContext();
            var companies = from c in db.Offices.OfType<Company>().ToList()
                            select new {
                                Id   = c.Id,
                                Name = c.Name,
                                ContactPerson = c.ContactPerson,
                                AddressLine1  = c.Address.Address1,
                                AddressLine2  = c.Address.Address2,
                                AddressCity   = c.Address.City,
                                AddressState  = c.Address.State,
                                AddressZip    = c.Address.Zip,
                                Mobile       = string.Join(" ",c.Contact1.Mobile,c.Contact2.Mobile),
                                Phone        = string.Join(" ",c.Contact1.Phone,c.Contact2.Mobile),
                                Email        = string.Join(" ",c.Contact1.Email,c.Contact2.Email),
                                Web          = string.Join(" ",c.Contact1.Website,c.Contact2.Website)
                            };
            JsonResult result = new JsonResult();
            result.Data = companies;
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;
        }

        public ContentResult CompanyUpdate(JsonOffice Company)
        {
            ContentResult Result = new ContentResult();
            try
            {
                ApplicationDBContext db = new ApplicationDBContext();
                LineFocus.Nikcron.Infrastructure.Enums.DatabaseOperation DbOperation = new Infrastructure.Enums.DatabaseOperation();
                Company UpdatingObject;
                if (Company.Id == null || Company.Id == 0)
                {
                    UpdatingObject = new Company();
                    DbOperation = Infrastructure.Enums.DatabaseOperation.Add;
                }
                else
                {
                    DbOperation = Infrastructure.Enums.DatabaseOperation.Update;
                    UpdatingObject = db.Offices.OfType<Company>().Where(c => c.Id == Company.Id).FirstOrDefault();
                }
                 
                UpdatingObject.Name = Company.Name;
                UpdatingObject.ContactPerson = Company.ContactPerson;
                UpdatingObject.Address.Address1 = Company.AddressLine1;
                UpdatingObject.Address.Address2 = Company.AddressLine2;
                UpdatingObject.Address.City = Company.AddressCity;
                UpdatingObject.Address.State = Company.AddressState;
                UpdatingObject.Address.Zip = Company.AddressZip;

                if(!string.IsNullOrEmpty(Company.Mobile))
                {
                    string[] mobileNumbers = Company.Mobile.Split(new char[' ']).ToArray();
                    if (Company.Mobile.Split(new char[' ']).Count() > 1)
                    {
                        UpdatingObject.Contact1.Mobile = mobileNumbers[0];
                        UpdatingObject.Contact2.Mobile = mobileNumbers[1];
                    }
                    else
                    {
                        UpdatingObject.Contact1.Mobile = Company.Mobile;
                        UpdatingObject.Contact2.Mobile = string.Empty;
                    }
                }

                if (!string.IsNullOrEmpty(Company.Phone))
                {
                    string[] phoneNumbers = Company.Phone.Split(new char[' ']).ToArray();
                    if (Company.Phone.Split(new char[' ']).Count() > 1)
                    {
                        UpdatingObject.Contact1.Phone = phoneNumbers[0];
                        UpdatingObject.Contact2.Phone = phoneNumbers[1];
                    }
                    else
                    {
                        UpdatingObject.Contact1.Phone = Company.Phone;
                        UpdatingObject.Contact2.Phone = string.Empty;
                    }
                }
                
                if(!string.IsNullOrEmpty(Company.Email))
                { 
                    string[] emails = Company.Email.Split(new char[' ']).ToArray();
                    if (Company.Email.Split(new char[' ']).Count() > 1)
                    {
                        UpdatingObject.Contact1.Email = emails[0];
                        UpdatingObject.Contact2.Email = emails[1];
                    }
                    else
                    {
                        UpdatingObject.Contact1.Email = Company.Email;
                        UpdatingObject.Contact2.Email = string.Empty;
                    }
                }

                if(!string.IsNullOrEmpty(Company.Web))
                { 
                    string[] webSites = Company.Web.Split(new char[' ']).ToArray();
                    if (Company.Web.Split(new char[' ']).Count() > 1)
                    {
                        UpdatingObject.Contact1.Website = webSites[0];
                        UpdatingObject.Contact2.Website = webSites[1];
                    }
                    else
                    {
                        UpdatingObject.Contact1.Website = Company.Web;
                        UpdatingObject.Contact2.Website = string.Empty;
                    }
                }
                if (DbOperation == Infrastructure.Enums.DatabaseOperation.Add)
                    db.Offices.AddObject(UpdatingObject);
                db.SaveChanges();
                Result.Content = Infrastructure.Enums.OperationResult.Success.ToString();
            }
            catch (Exception exception)
            {
                Result.Content = Infrastructure.Enums.OperationResult.Failure.ToString();
            }
            return Result;
        }
    }
}
