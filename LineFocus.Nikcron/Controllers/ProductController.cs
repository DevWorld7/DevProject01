using Nickron.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LineFocus.Nikcron.Controllers
{
    public class ProductController : Controller
    {
        //
        // GET: /Product/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Manufacture()
        {
            return View();
        }

        public ActionResult ManufactureMaintenance()
        {
            return View();
        }

        public ActionResult Laptops()
        {
            ViewBag.Header = "Laptops";
            ViewBag.Caption = "Listing";
            return View();
        }

        public JsonResult GetLaptops()
        {
            JsonResult Result = new JsonResult();
            ApplicationDBContext db = new ApplicationDBContext();
            Result.Data  = db.ProductModels.OfType<Laptop>().Select(n => new
            {
                n.Id,
                n.ModelNumber,
                Brand = n.Manufacture.Name,
                OS = n.OperatingSystem,
                HDD = n.InternalStorage,
                RAM = n.Memory,
                Processor = n.Processor,
                Screen = n.DisplaySize
            });
            Result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return Result;
        }

        public ActionResult LaptopMaintenance()
        {
            return View();
        }

        public ActionResult Mobilephones(Int32? MobileId)
        {
            return View();
        }
        public JsonResult GetMobiles()
        {
            JsonResult Result = new JsonResult();
            ApplicationDBContext db = new ApplicationDBContext();
            Result.Data = db.ProductModels.OfType<Mobile>().Select(n => new
            {
                n.Id,
                n.ModelNumber,
                Brand = n.Manufacture.Name,
                OS = n.OperatingSystem,
                Storage = n.InternalStorage,
                RAM = n.Memory,
                Processor = n.Processor,
                Screen = n.DisplaySize
            });
            Result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return Result;
        }
        [HttpGet]
        public ActionResult MobilephoneMaintenance(Int32? MobileId)
        {
            ViewBag.Header = "Mobiles";
            if (MobileId.HasValue)
            {
                ViewBag.MobileId = MobileId;
                ViewBag.Caption = "Edit";
                ApplicationDBContext db = new ApplicationDBContext();
                Mobile Mobile = db.ProductModels.OfType<Mobile>().Where(m => m.Id == MobileId).FirstOrDefault();
                return View(Mobile);
            }
            else
            {
                ViewBag.MobileId = 0;
                ViewBag.Caption = "New";
                return View(new Mobile());
            }
        }
        [HttpPost]
        public ActionResult MobilephoneMaintenance(FormCollection formCollection)
        {
            ApplicationDBContext db = new ApplicationDBContext();
            Mobile MobilePhone = new Mobile();     

            Int32 MobileId = 0;
            Int32.TryParse(formCollection["MobileId"], out MobileId);
            if (MobileId == 0)
                MobilePhone = new Mobile();
            else
                MobilePhone = db.ProductModels.OfType<Mobile>().Where(m => m.Id == MobileId).FirstOrDefault();

            MobilePhone.ProductTypeId = db.ProductTypes.Where(t => t.Name == "Mobile").FirstOrDefault().Id;
            MobilePhone.ManufactureId = int.Parse(formCollection["Manufacture"]);
            MobilePhone.ModelNumber = formCollection["ModelNumber"];
            MobilePhone.ModelName = formCollection["ModelName"];
            MobilePhone.FormFactor = formCollection["FormFactor"];
            MobilePhone.CallFeatures = formCollection["CallFeatures"];
            MobilePhone.SimSize = formCollection["SimSize"];
            MobilePhone.SimType = formCollection["SimType"];
            MobilePhone.PrimaryCamera = formCollection["PrimaryCamera"];
            MobilePhone.SecondryCamera = formCollection["SecondryCamera"];
            MobilePhone.PhoneMemory = formCollection["PhoneMemory"];
            MobilePhone.VideoRecording = formCollection["VideoRecording"];
            MobilePhone.Dimension = formCollection["Dimension"];
            MobilePhone.Weight = formCollection["Weight"];
            MobilePhone.BatteryType = formCollection["BatteryType"];
            //if (!string.IsNullOrEmpty(formCollection["BatteryStandBy"]))
            //    MobilePhone.BatteryStandBy = formCollection["BatteryStandBy"];
            MobilePhone.MusicPlayer = formCollection["MusicPlayer"];
            MobilePhone.VideoPlayer = formCollection["VideoPlayer"];
            MobilePhone.FM = formCollection["FM"];
            MobilePhone.SoundEnhancement = formCollection["SoundEnhancement"];
            MobilePhone.RingTone = formCollection["RingTone"];
            //MobilePhone. = formCollection["ProductWarranties"];
            MobilePhone.Connectivity.OperatingFrequencies = formCollection["OperatingFrequencies"];
            MobilePhone.OperatingSystem = formCollection["OperatingSystem"];
            MobilePhone.Processor = formCollection["Processor"];
            MobilePhone.DisplayType = formCollection["DisplayType"];
            MobilePhone.DisplaySize = formCollection["DisplaySize"];
            MobilePhone.DisplayResolution = formCollection["DisplayResolution"];
            MobilePhone.InternalStorage = formCollection["InternalStorage"];
            MobilePhone.ExternalStorage = formCollection["ExternalStorage"];
            MobilePhone.Memory = formCollection["Memory"];
            MobilePhone.InternetFeatures = formCollection["InternetFeatures"];
            MobilePhone.PreinstalledBrowser = formCollection["PreinstalledBrowser"];
            MobilePhone.Connectivity.HSPA_3G = formCollection["HSPA_3G"];
            MobilePhone.Connectivity.GPRS_2G = formCollection["GPRS_2G"];
            MobilePhone.WiFi = formCollection["WiFi"];
            MobilePhone.Connectivity.USB = formCollection["USB"];
            MobilePhone.Connectivity.Bluetooth = formCollection["Bluetooth"];
            MobilePhone.Connectivity.SupportedNetworks = formCollection["SupportedNetworks"];
            MobilePhone.CallMemory = formCollection["CallMemory"];
            MobilePhone.SMSMemory = formCollection["SMSMemory"];
            MobilePhone.PhoneMemory = formCollection["PhoneMemory"];
            if(MobileId == 0)
                db.ProductModels.AddObject(MobilePhone);
            db.SaveChanges();
            return View("Mobilephones");
        }
        public ActionResult Tablets()
        {
            return View();
        }

        public ActionResult TabletMaintenance()
        {
            return View();
        }
    }
}
