using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace testingdeploy.Controllers
{
    using Microsoft.ApplicationInsights;

    public class PunchOutOciController : Controller
    {


        private string a;
        TelemetryClient _log = new Microsoft.ApplicationInsights.TelemetryClient();

        [HttpPost]
        public ActionResult PunchoutLoginUrl()
        {
            _log.TrackTrace("punchout oci request " + DateTime.Now.ToString());

            return View();
        }
    }
}