using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace testingdeploy.Controllers
{
    public class HomeController : Controller
    {

        //[HttpPost]
        public ActionResult PunchoutSetupRequest()
        {

            FileStream fs = new FileStream(@"\out.txt", FileMode.Open, FileAccess.ReadWrite);
            using (StreamReader sr = new StreamReader(fs))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.WriteLine(DateTime.Now.ToString(CultureInfo.InvariantCulture));
                }
            }



            //using (StreamWriter outputFile = new StreamWriter(@"out.txt"))
            //{
            //    outputFile.WriteLine(DateTime.Now.ToString(CultureInfo.InvariantCulture));
            //    outputFile.WriteLine("ok");
            //    outputFile.WriteLine();
            //}

            ViewBag.result = "run is ok";



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