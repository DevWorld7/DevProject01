using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LineFocus.Nikcron.Controllers
{
    public class PurchaseOrderController : Controller
    {
        //
        // GET: /PurchaseOrder/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PurchaseOrderMaintenance()
        {
            return View();
        }

    }
}
