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

        [HttpGet]
        public ActionResult LaptopMaintenance(Int32? LaptopId)
        {
            ViewBag.Header = "Laptop";
            if (LaptopId.HasValue)
            {
                ViewBag.LaptopId = LaptopId;
                ViewBag.Caption = "Edit";
                ApplicationDBContext db = new ApplicationDBContext();
                Laptop loptop = db.ProductModels.OfType<Laptop>().Where(l => l.Id == LaptopId).FirstOrDefault();
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
            Laptop.ModelName = formCollection["ModelName"];
            Laptop.ModelNumber = formCollection["ModelNumber"];
           // Laptop.ProductColors = formCollection["ProductColors"];
            Laptop.Processor = formCollection["Processor"];
            Laptop.Chipset = formCollection["Chipset"];
            Laptop.ClockSpeed = formCollection["ClockSpeed"];
            Laptop.Cache = formCollection["Cache"];
            Laptop.ExternalStorage = formCollection["ExternalStorage"];
            Laptop.HardwareInterface = formCollection["HardwareInterface"];
            Laptop.RPM = formCollection["RPM"];
            Laptop.HDDCapacity = formCollection["HDDCapacity"];
            Laptop.OpticalDrive = formCollection["OpticalDrive"];
            //Laptop.ProductWarranties = formCollection["ProductWarranties"];
            Laptop.OperatingSystem = formCollection["OperatingSystem"];
            Laptop.SystemArch = formCollection["SystemArch"];
            Laptop.DisplaySize = formCollection["DisplaySize"];
            Laptop.DisplayType = formCollection["DisplayType"];
            Laptop.Keyboard = formCollection["Keyboard"];
            Laptop.Speakers = formCollection["Speakers"];
            Laptop.Sound = formCollection["Sound"];
            Laptop.USBPort = formCollection["USBPort"];
            Laptop.RJ45LAN = formCollection["RJ45LAN"];
            Laptop.HDMIPort = formCollection["HDMIPort"];
            Laptop.VGAPort = formCollection["VGAport"];
            Laptop.MultiCardSlot = formCollection["MultiCardSlot"];
            Laptop.Weight = formCollection["Weight"];
            

            if (LaptopId == 0)
                db.ProductModels.AddObject(Laptop);
            db.SaveChanges();
            return View("Laptops");
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

        public JsonResult GetTablets()
        {
            JsonResult Result = new JsonResult();
            ApplicationDBContext db = new ApplicationDBContext();
            Result.Data = db.ProductModels.OfType<Tablet>().Select(n => new
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

       [HttpGet]
        public ActionResult TabletMaintenance(Int32? TabletId)
        {
            ViewBag.Header = "Tablet";
            if (TabletId.HasValue)
            {
                ViewBag.TabletId = TabletId;
                ViewBag.Caption = "Edit";
                ApplicationDBContext db = new ApplicationDBContext();
                Tablet Tablet = db.ProductModels.OfType<Tablet>().Where(t => t.Id == TabletId).FirstOrDefault();
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
           Tablet.ModelName = formCollection["ModelName"];
           Tablet.ModelNumber = formCollection["ModelNumber"];
          
           Tablet.Processor = formCollection["Processor"];
          // Tablet.ProductColors = formCollection["ProductColors"];
           Tablet.ExternalStorage = formCollection["ExternalStorage"];
           Tablet.InternalStorage = formCollection["InternalStorage"];
           Tablet.Dimension = formCollection["Dimension"];
           Tablet.OperatingSystem = formCollection["OperatingSystem"];
           Tablet.DisplaySize = formCollection["DisplaySize"];
           Tablet.DisplayType = formCollection["DisplayType"];
           Tablet.PrimaryCamera = formCollection["PrimaryCamera"];
           Tablet.SecondryCamera = formCollection["SecondryCamera"];
           Tablet.WiFi = formCollection["WiFi"];
           //Tablet.USBPort = formCollection["USBPort"];
           Tablet.PreinstalledBrowser = formCollection["PreinstalledBrowser"];
           Tablet.Weight = formCollection["Weight"];
           Tablet.VideoFormat = formCollection["VideoFormat"];
           Tablet.VideoRecording = formCollection["VideoRecording"];
           Tablet.AudioFormat = formCollection["AudioFormat"];

           if (Tabletid == 0)
               db.ProductModels.AddObject(Tablet);
           db.SaveChanges();
           return View("Tablets");
       }

    }
}
