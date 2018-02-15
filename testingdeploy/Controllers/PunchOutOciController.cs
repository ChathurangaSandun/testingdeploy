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

        [HttpGet]
        public ActionResult PunchoutLoginUrl(string USERNAME, string PASSWORD, string HOOK_URL)
        {
            _log.TrackTrace("punchout oci request " + DateTime.Now.ToString());
            _log.TrackTrace("HOOK_URL");

            var valied = this.UserValid(USERNAME, PASSWORD);

            return this.View("CartPage");
        }

        private bool UserValid(string username, string password)
        {
            if (username == "sandun" && password == "password")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}