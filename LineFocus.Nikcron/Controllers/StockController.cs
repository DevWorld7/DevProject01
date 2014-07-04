using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LineFocus.Nikcron.Controllers
{
    public class StockController : Controller
    {
        //
        // GET: /Stock/

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult StockMaintenance()
        {
            return View();
        }

    }
}
