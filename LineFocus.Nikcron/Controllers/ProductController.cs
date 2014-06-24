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

        public ActionResult Mobilephones()
        {
            return View();
        }

        public ActionResult MobilephoneMaintenance()
        {
            return View();
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
