using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Xml.Serialization;
using Microsoft.ApplicationInsights;
using testingdeploy.Models;

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

            var xmlSerializer = new XmlSerializer(typeof(MainRequest));

            MainRequest request = (MainRequest)xmlSerializer.Deserialize(new StringReader(xml.ToString()));
            Session["BROWSER_URL"] = request.Request.PunchOutSetupRequest.BrowserFormPost.URL;


            MainResponse mainResponse = new MainResponse()
            {
                PayloadID = request.PayloadID,
                Timestamp = request.Timestamp,
                Response = new Response()
                {
                    Status = new Status()
                    {
                        Code = "200",
                        Text = "Ok"
                    },
                    PunchOutSetupResponse = new PunchOutSetupResponse()
                    {
                        StartPage = new StartPage()
                        {
                            URL = "https://kumara.azurewebsites.net/home/index"
                        }
                    }

                }
            };

            var stringwriter = new StringWriter();

            XmlSerializer serializer = new XmlSerializer(typeof(MainResponse));
            serializer.Serialize(stringwriter, mainResponse);
            var responseTest = stringwriter.ToString().Replace("utf-16","utf-8");

            _log.TrackTrace(responseTest);

            return Content(responseTest);
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