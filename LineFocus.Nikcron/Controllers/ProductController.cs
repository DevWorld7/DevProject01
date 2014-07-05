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

        #region Laptops
        [HttpGet]
        public ActionResult Laptops()
        {
            ViewBag.Header = "Laptops";
            ViewBag.Caption = "Listing";
            return View();
        }
        [HttpGet]
        public JsonResult GetLaptops()
        {
            JsonResult Result = new JsonResult();
            ApplicationDBContext db = new ApplicationDBContext();
            Result.Data  = db.ProductModels.OfType<Laptop>().Select(n => new
            {
                n.Id,
                Manufacture = n.Manufacture.Name,
                n.ModelName,
                n.ModelNumber,
                n.ProductColors,
                n.Processor,
                n.Chipset,
                n.ClockSpeed,
                n.Cache,
                n.ExternalStorage,
                n.HardwareInterface,
                n.RPM,
                n.InternalStorage,
                n.HDDCapacity,
                n.OpticalDrive,
                n.WarrantySummary,                
                n.OperatingSystem,
                n.SystemArch,
                n.DisplaySize,
                n.DisplayType,
                n.Keyboard,
                n.Speakers,
                n.Sound,
                n.USBPort,
                n.RJ45LAN,
                n.HDMIPort,
                n.VGAPort,
                n.MultiCardSlot,
                n.Weight
            });
            Result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return Result;
        }
        [HttpGet]
        public ActionResult LaptopMaintenance(Int32? Id)
        {
            ViewBag.Header = "Laptop";
            if (Id.HasValue)
            {
                ViewBag.Id = Id;
                ViewBag.Caption = "Edit";
                ApplicationDBContext db = new ApplicationDBContext();
                Laptop loptop = db.ProductModels.OfType<Laptop>().Where(l => l.Id == Id).FirstOrDefault();
                return View(loptop);
            }
            else
            {
                ViewBag.LaptopId = 0;
                ViewBag.Caption = "New";
                return View(new Laptop());
            }
        }
        [HttpPost]
        public ActionResult LaptopMaintenance(FormCollection formCollection)
        {
            ApplicationDBContext db = new ApplicationDBContext();
            Laptop Laptop = new Laptop();

            Int32 LaptopId = 0;
            Int32.TryParse(formCollection["Laptopid"], out LaptopId);
            if (LaptopId == 0)
                Laptop = new Laptop();
            else

            Laptop = db.ProductModels.OfType<Laptop>().Where(l => l.Id == LaptopId).FirstOrDefault();
            Laptop.ProductTypeId = db.ProductTypes.Where(t => t.Name == "Laptop").FirstOrDefault().Id;
            Laptop.ManufactureId = int.Parse(formCollection["Manufacture"]);
            Laptop.ProductDate = DateTime.Parse(formCollection["ProductDate"]);
            Laptop.InBox = formCollection["InBox"];
            Laptop.ModelName = formCollection["ModelName"];
            Laptop.ModelNumber = formCollection["ModelNumber"];
            //Laptop.ProductColors = formCollection["ProductColors"];
            
            Laptop.Processor = formCollection["Processor"];
            Laptop.Chipset = formCollection["Chipset"];
            Laptop.ClockSpeed = formCollection["ClockSpeed"];
            Laptop.Cache = formCollection["Cache"];
            Laptop.ExternalStorage = formCollection["ExternalStorage"];
            Laptop.HardwareInterface = formCollection["HardwareInterface"];
            Laptop.RPM = formCollection["RPM"];
            Laptop.HDDCapacity = formCollection["HDDCapacity"];
            Laptop.OpticalDrive = formCollection["OpticalDrive"];
            Laptop.NoteSummary = formCollection["NoteSummary"];
            Laptop.WarrantySummary = formCollection["WarrantySummary"];
            Laptop.OperatingSystem = formCollection["OperatingSystem"];
            Laptop.SystemArch = formCollection["SystemArch"];
            Laptop.DisplaySize = formCollection["DisplaySize"];
            Laptop.DisplayType = formCollection["DisplayType"];
            Laptop.GraphicProcessor = formCollection["GraphicProcessor"];
            Laptop.Keyboard = formCollection["Keyboard"];
            Laptop.Speakers = formCollection["Speakers"];
            Laptop.Sound = formCollection["Sound"];
            Laptop.USBPort = formCollection["USBPort"];
            Laptop.RJ45LAN = formCollection["RJ45LAN"];
            Laptop.HDMIPort = formCollection["HDMIPort"];
            Laptop.VGAPort = formCollection["VGAport"];
            Laptop.MultiCardSlot = formCollection["MultiCardSlot"];
            Laptop.Dimension = formCollection["Dimension"];
            Laptop.Weight = formCollection["Weight"];
            

            if (LaptopId == 0)
                db.ProductModels.AddObject(Laptop);
            db.SaveChanges();
            return View("Laptops");
        }
        #endregion

        #region Mobiles

        [HttpGet]
        public ActionResult Mobilephones()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetMobiles()
        {
            JsonResult Result = new JsonResult();
            ApplicationDBContext db = new ApplicationDBContext();
            Result.Data = db.ProductModels.OfType<Mobile>().Select(n => new
            {
                n.Id,
                Manufacture = n.Manufacture.Name,
                n.ModelNumber,
                n.ModelName,
                n.FormFactor,
                n.CallFeatures,
                n.SimSize,
                n.SimType,
                n.PrimaryCamera,
                n.SecondryCamera,
                n.PhoneMemory,
                n.VideoRecording,
                n.Dimension,
                n.Weight,
                n.BatteryType,
                n.BatteryStandBy,
                n.MusicPlayer,
                n.VideoPlayer,
                n.FM,
                n.SoundEnhancement,
                n.RingTone,
                n.WarrantySummary,
                n.Connectivity.OperatingFrequencies,
                n.OperatingSystem,
                n.Processor,
                n.DisplayType,
                n.DisplaySize,
                n.DisplayResolution,
                n.InternalStorage,
                n.ExternalStorage,
                n.Memory,
                n.InternetFeatures,
                n.PreinstalledBrowser,
                n.Connectivity.HSPA_3G,
                n.Connectivity.GPRS_2G,
                n.WiFi,
                n.Connectivity.USB,
                n.Connectivity.Bluetooth,
                n.Connectivity.SupportedNetworks,
                n.CallMemory,
                n.SMSMemory
            });
            Result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return Result;
        }
        [HttpGet]
        public ActionResult MobilephoneMaintenance(Int32? Id)
        {
            ViewBag.Header = "Mobiles";
            if (Id.HasValue)
            {
                ViewBag.MobileId = Id;
                ViewBag.Caption = "Edit";
                ApplicationDBContext db = new ApplicationDBContext();
                Mobile Mobile = db.ProductModels.OfType<Mobile>().Where(m => m.Id == Id).FirstOrDefault();
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
            Int32.TryParse(formCollection["Id"], out MobileId);
            if (MobileId == 0)
                MobilePhone = new Mobile();
            else
                MobilePhone = db.ProductModels.OfType<Mobile>().Where(m => m.Id == MobileId).FirstOrDefault();

            MobilePhone.ProductTypeId = db.ProductTypes.Where(t => t.Name == "Mobile").FirstOrDefault().Id;            
            MobilePhone.ManufactureId = int.Parse(formCollection["Manufacture"]);
            MobilePhone.ProductDate = DateTime.Parse(formCollection["ProductDate"]);
            MobilePhone.InBox = formCollection["InBox"];
            MobilePhone.ModelNumber = formCollection["ModelNumber"];
            MobilePhone.ModelName = formCollection["ModelName"];
            MobilePhone.FormFactor = formCollection["FormFactor"];
            MobilePhone.CallFeatures = formCollection["CallFeatures"];
            MobilePhone.SimSize = formCollection["SimSize"];
            MobilePhone.SimType = formCollection["SimType"];
            MobilePhone.PrimaryCamera = formCollection["PrimaryCamera"];
            MobilePhone.SecondryCamera = formCollection["SecondryCamera"];           
            MobilePhone.VideoRecording = formCollection["VideoRecording"];
            MobilePhone.Dimension = formCollection["Dimension"];
            MobilePhone.Weight = formCollection["Weight"];
            MobilePhone.BatteryType = formCollection["BatteryType"];
           // if (!string.IsNullOrEmpty(formCollection["BatteryStandBy"]))
            //    MobilePhone.ModelNumber = formCollection["BatteryStandBy"];
            MobilePhone.BatteryCapacity = formCollection["BatteryCapacity"];
            MobilePhone.MusicPlayer = formCollection["MusicPlayer"];
            MobilePhone.VideoPlayer = formCollection["VideoPlayer"];            
            MobilePhone.SoundEnhancement = formCollection["SoundEnhancement"];
            MobilePhone.RingTone = formCollection["RingTone"];
            MobilePhone.FM = formCollection["FM"];
            MobilePhone.WarrantySummary = formCollection["WarrantySummary"];            
            //MobilePhone. = formCollection["ProductWarranties"];
            MobilePhone.Connectivity.OperatingFrequencies = formCollection["OperatingFrequencies"];
            MobilePhone.OperatingSystem = formCollection["OperatingSystem"];
            MobilePhone.Processor = formCollection["Processor"];
            MobilePhone.DisplayType = formCollection["DisplayType"];
            MobilePhone.DisplaySize = formCollection["DisplaySize"];
            MobilePhone.DisplayResolution = formCollection["DisplayResolution"];
            MobilePhone.InternalStorage = formCollection["InternalStorage"];
            MobilePhone.ExternalStorage = formCollection["ExternalStorage"];
            MobilePhone.PhoneMemory = formCollection["PhoneMemory"];
           // MobilePhone.Memory = formCollection["Memory"];
            MobilePhone.InternetFeatures = formCollection["InternetFeatures"];
            MobilePhone.PreinstalledBrowser = formCollection["PreinstalledBrowser"];
            MobilePhone.Connectivity.HSPA_3G = formCollection["HSPA_3G"];
            MobilePhone.Connectivity.GPRS_2G = formCollection["GPRS_2G"];
            MobilePhone.Connectivity.EDGE_2G = formCollection["EDGE_2G"];
            MobilePhone.WiFi = formCollection["WiFi"];
            MobilePhone.Connectivity.Hotspot = formCollection["Hotspot"];
            MobilePhone.Connectivity.USB = formCollection["USB"];
            MobilePhone.Connectivity.Bluetooth = formCollection["Bluetooth"];
            MobilePhone.Connectivity.SupportedNetworks = formCollection["SupportedNetworks"];
           // MobilePhone.CallMemory = formCollection["CallMemory"];
           // MobilePhone.SMSMemory = formCollection["SMSMemory"];
            MobilePhone.NoteSummary = formCollection["NoteSummary"];
            if(MobileId == 0)
                db.ProductModels.AddObject(MobilePhone);
            db.SaveChanges();
            return View("Mobilephones");
        }
        #endregion

        #region Tablets
        [HttpGet]
        public ActionResult Tablets()
        {
            return View();
        }
        [HttpGet]
        public JsonResult GetTablets()
        {
            JsonResult Result = new JsonResult();
            ApplicationDBContext db = new ApplicationDBContext();
            Result.Data = db.ProductModels.OfType<Tablet>().Select(n => new
            {
                n.Id,
                Manufacture = n.Manufacture.Name,
                n.ModelNumber,
                n.ModelName,
                n.Processor,
                n.ProductColors,
                n.ExternalStorage,
                n.InternalStorage,
                n.Dimension,
                n.OperatingSystem,
                n.DisplaySize,
                n.DisplayType,
                n.PrimaryCamera,
                n.SecondryCamera,
                n.WiFi,
                n.PreinstalledBrowser,
                n.Weight,
                n.VideoFormat,
                n.VideoRecording,
                n.AudioFormat
            });
            Result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return Result;
        }
        [HttpGet]
        public ActionResult TabletMaintenance(Int32? Id)
        {
            ViewBag.Header = "Tablet";
            if (Id.HasValue)
            {
                ViewBag.TabletId = Id;
                ViewBag.Caption = "Edit";
                ApplicationDBContext db = new ApplicationDBContext();
                Tablet Tablet = db.ProductModels.OfType<Tablet>().Where(t => t.Id == Id).FirstOrDefault();
                return View(Tablet);
            }
            else
            {
                ViewBag.TabletId = 0;
                ViewBag.Caption = "New";
                return View(new Tablet());
            }
        }
        [HttpPost]
        public ActionResult TabletMaintenance(FormCollection formCollection)
        {
           ApplicationDBContext db = new ApplicationDBContext();
           Tablet Tablet = new Tablet();

           Int32 Tabletid = 0;
           Int32.TryParse(formCollection["Tabletid"], out Tabletid);
           if (Tabletid == 0)
               Tablet = new Tablet();
           else

               Tablet = db.ProductModels.OfType<Tablet>().Where(t => t.Id == Tabletid).FirstOrDefault();
           Tablet.ProductTypeId = db.ProductTypes.Where(t => t.Name == "Tablet").FirstOrDefault().Id;
           Tablet.ManufactureId = int.Parse(formCollection["Manufacture"]);

           Tablet.ProductDate = DateTime.Parse(formCollection["ProductDate"]);
           Tablet.InBox = formCollection["InBox"];
           Tablet.ModelName = formCollection["ModelName"];
           Tablet.ModelNumber = formCollection["ModelNumber"];
           Tablet.CallFeatures = formCollection["CallFeatures"];
           Tablet.Processor = formCollection["Processor"];
          // Tablet.ProductColors = formCollection["ProductColors"];
           Tablet.ExternalStorage = formCollection["ExternalStorage"];
           Tablet.InternalStorage = formCollection["InternalStorage"];
           Tablet.Dimension = formCollection["Dimension"];
           Tablet.Weight = formCollection["Weight"];
           Tablet.NoteSummary = formCollection["NoteSummary"];
           Tablet.WarrantySummary = formCollection["WarrantySummary"];
           Tablet.OperatingSystem = formCollection["OperatingSystem"];
           Tablet.DisplaySize = formCollection["DisplaySize"];
           Tablet.DisplayType = formCollection["DisplayType"];
           Tablet.PrimaryCamera = formCollection["PrimaryCamera"];
           Tablet.SecondryCamera = formCollection["SecondryCamera"];          
           Tablet.PreinstalledBrowser = formCollection["PreinstalledBrowser"];
           Tablet.WiFi = formCollection["WiFi"];
           Tablet.Connectivity.USB = formCollection["USBPort"];
           Tablet.Connectivity.HSPA_3G = formCollection["HSPA_3G"];
           Tablet.Connectivity.GPRS_2G = formCollection["GPRS_2G"];         
           Tablet.VideoFormat = formCollection["VideoFormat"];
           Tablet.VideoRecording = formCollection["VideoRecording"];
           Tablet.AudioFormat = formCollection["AudioFormat"];

           if (Tabletid == 0)
               db.ProductModels.AddObject(Tablet);
           db.SaveChanges();
           return View("Tablets");
        }
        #endregion
    }
}
