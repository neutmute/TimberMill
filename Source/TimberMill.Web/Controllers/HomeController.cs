using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kraken.Framework.Core;

namespace TimberMill.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.AppData = ExecutionEnvironment.GetApplicationMetadata(); ;

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
