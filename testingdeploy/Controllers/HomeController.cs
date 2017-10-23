using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.ApplicationInsights;

namespace testingdeploy.Controllers
{
    public class HomeController : Controller
    {
        TelemetryClient _log = new Microsoft.ApplicationInsights.TelemetryClient();


        //[HttpPost]
        public ActionResult PunchoutSetupRequest()
        {

            _log.TrackTrace("Ok " + DateTime.Now.ToString());


            var req = Request.InputStream;
            var xml = new StreamReader(req).ReadToEnd();

            _log.TrackTrace(xml.ToString());






            return View();
        }






        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}