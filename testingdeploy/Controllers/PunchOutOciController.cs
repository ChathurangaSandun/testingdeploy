namespace testingdeploy.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using System.Globalization;
    using System.IO;
    using System.Net;
    using System.Net.Http;
    using System.Text;
    using Microsoft.Ajax.Utilities;
    using Microsoft.ApplicationInsights;
    using testingdeploy.Models;

    public class PunchOutOciController : Controller
    {
        private static string _hookUrl;

        private string a;
        TelemetryClient _log = new Microsoft.ApplicationInsights.TelemetryClient();

        [HttpGet]
        public ActionResult PunchoutLoginUrl(string USERNAME, string PASSWORD, string HOOK_URL)
        {
            _log.TrackTrace("punchout oci request " + DateTime.Now.ToString());
            _log.TrackTrace("HOOK_URL");
            _hookUrl = HOOK_URL;


            var valied = this.UserValid(USERNAME, PASSWORD);
            if (valied)
            {
                return RedirectToAction("CartPage", "PunchOutOci");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

        }

        private bool UserValid(string username, string password)
        {
            if (username == "sandun" && password == "123456")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public ActionResult CartPage()
        {
            List<OciOrderItem> orderItems = new List<OciOrderItem>();
            orderItems.Add(new OciOrderItem()
            {
                Description = "Item1",
                Quantity = 10,
                Unit = "EA",
                Price = 10000000000000000000.22,
                Currency = "NZD",
                LeadTime = 10,
                VendorMat = "43100100",
                MatGroup = "43100103"
            });

            orderItems.Add(new OciOrderItem()
            {
                Description = "Item2",
                Quantity = 20,
                Unit = "EA",
                Price = 50,
                Currency = "NZD",
                LeadTime = 5,
                VendorMat = "1234567",
                MatGroup = "5863145"
            });

            ViewBag.hook_url = _hookUrl;
            ViewBag.ItemList = orderItems;
            return this.View("CartPage", orderItems);
        }

      /*  public void PunchoutHookOci()
        {
            List<OciOrderItem> orderItems = new List<OciOrderItem>();
            orderItems.Add(new OciOrderItem()
            {
                Description = "Item1",
                Quantity = 10,
                Unit = "EA",
                Price = 10.22,
                Currency = "NZD",
                LeadTime = 10,
                VendorMat = "43100100",
                MatGroup = "43100103"
            });

            orderItems.Add(new OciOrderItem()
            {
                Description = "Item2",
                Quantity = 20,
                Unit = "EA",
                Price = 50,
                Currency = "NZD",
                LeadTime = 5,
                VendorMat = "1234567",
                MatGroup = "5863145"
            });


            Dictionary<string, object> itemDetailsDictionary = new Dictionary<string, object>();

            string[] itemNames =
                {
                        "NEW_ITEM-DESCRIPTION[n]", "NEW_ITEM-QUANTITY[n]", "NEW_ITEM-UNIT[n]", "NEW_ITEM-PRICE[n]",
                        "NEW_ITEM-CURRENCY[n]", "NEW_ITEM-LEADTIME[n]", "NEW_ITEM-VENDORMAT[n]", "NEW_ITEM-MATGROUP[n]"
                    };

            ASCIIEncoding encoding = new ASCIIEncoding();
            string d = String.Empty;

            int i = 1;
            foreach (var item in orderItems)
            {
                d += @"NEW_ITEM-DESCRIPTION[" + i + "]=" + item.Description;
                d += @"&NEW_ITEM-QUANTITY[" + i + "]=" + item.Quantity;
                d += @"&NEW_ITEM-UNIT[" + i + "]=" + item.Unit;
                d += @"&NEW_ITEM-PRICE[" + i + "]=" + item.Price;
                d += @"&NEW_ITEM-CURRENCY[" + i + "]=" + item.Currency;
                d += @"&NEW_ITEM-LEADTIME[" + i + "]=" + item.LeadTime;
                d += @"&NEW_ITEM-VENDORMAT[" + i + "]=" + item.VendorMat;
                d += @"&NEW_ITEM-MATGROUP[" + i + "]=" + item.MatGroup;
                i++;
            }

            this._log.TrackTrace(d);
            byte[] data = encoding.GetBytes(d);
        }
        
        public  ActionResult PostData()
        {
           string d = string.Empty;
            int i = 1;
            foreach (var item in orderItems)
            {
                d += "NEW_ITEM-DESCRIPTION[" + i + "]=" + item.Description;
                d += "&NEW_ITEM-QUANTITY[" + i + "]=" + item.Quantity;
                d += "&NEW_ITEM-UNIT[" + i + "]=" + item.Unit;
                d += "&NEW_ITEM-PRICE[" + i + "]=" + item.Price;
                d += "&NEW_ITEM-CURRENCY[" + i + "]=" + item.Currency;
                d += "&NEW_ITEM-LEADTIME[" + i + "]=" + item.LeadTime;
                d += "&NEW_ITEM-VENDORMAT[" + i + "]=" + item.VendorMat;
                d += "&NEW_ITEM-MATGROUP[" + i + "]=" + item.MatGroup;
                i++;
            }

            try
            {
                using (WebClient client = new WebClient())
                {
                    var reqparm = new System.Collections.Specialized.NameValueCollection();
                    reqparm.Add("NEW_ITEM-DESCRIPTION[1]", "Article number 1");
                    reqparm.Add("NEW_ITEM-QUANTITY[1]", "1");
                    byte[] responsebytes = client.UploadValues(_hookUrl, "POST", reqparm);
                    string responsebody = Encoding.UTF8.GetString(responsebytes);
                }

                /*HttpWebRequest request = (HttpWebRequest)WebRequest.Create(_hookUrl);
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                string postData = d;
                byte[] bytes = Encoding.UTF8.GetBytes(postData);
                request.ContentLength = bytes.Length;

                Stream requestStream = request.GetRequestStream();
                requestStream.Write(bytes, 0, bytes.Length);

                WebResponse response = request.GetResponse();
                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream);

                var result = reader.ReadToEnd();
                stream.Dispose();
                reader.Dispose();#1#

                return View();
            }
            catch (Exception e)
            {
                this._log.TrackException(e);
                throw;
            }
        }*/
    }
}