using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace testingdeploy.Controllers
{
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
            ViewBag.hook_url = _hookUrl;
            return this.View("CartPage");
        }

        public void PunchoutHookOci()
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


        [HttpPost]
        public async void PostData()
        {
            //// Create a request using a URL that can receive a post.   
            //WebRequest request = WebRequest.Create(_hookUrl);
            //// Set the Method property of the request to POST.  
            //request.Method = "POST";
            //// Create POST data and convert it to a byte array.  
            //string postData = d;
            //byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            //// Set the ContentType property of the WebRequest.  
            //request.ContentType = "application/x-www-form-urlencoded";
            //// Set the ContentLength property of the WebRequest.  
            //request.ContentLength = byteArray.Length;
            //// Get the request stream.  
            //Stream dataStream = request.GetRequestStream();
            //// Write the data to the request stream.  
            //dataStream.Write(byteArray, 0, byteArray.Length);
            //// Close the Stream object.  
            //dataStream.Close();
            //// Get the response.  
            //WebResponse response = request.GetResponse();
            //// Display the status.  
            //Console.WriteLine(((HttpWebResponse)response).StatusDescription);
            //// Get the stream containing content returned by the server.  
            //dataStream = response.GetResponseStream();
            //// Open the stream using a StreamReader for easy access.  
            //StreamReader reader = new StreamReader(dataStream);
            //// Read the content.  
            //string responseFromServer = reader.ReadToEnd();
            //// Display the content.  
            //Console.WriteLine(responseFromServer);
            //// Clean up the streams.  
            //reader.Close();
            //dataStream.Close();
            //response.Close();

            ////HttpWebRequest myRequest =
            ////    (HttpWebRequest)WebRequest.Create(_hookUrl);
            ////myRequest.Method = "POST";
            ////myRequest.ContentType = "application/x-www-form-urlencoded";
            ////myRequest.ContentLength = data.Length;
            ////Stream newStream = myRequest.GetRequestStream();
            ////newStream.Write(data, 0, data.Length);
            ////newStream.Close();

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

            //string[] itemNames =
            //    {
            //            "NEW_ITEM-DESCRIPTION[n]", "NEW_ITEM-QUANTITY[n]", "NEW_ITEM-UNIT[n]", "NEW_ITEM-PRICE[n]",
            //            "NEW_ITEM-CURRENCY[n]", "NEW_ITEM-LEADTIME[n]", "NEW_ITEM-VENDORMAT[n]", "NEW_ITEM-MATGROUP[n]"
            //        };

            string d = string.Empty;
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

            //try
            //{
            //    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(_hookUrl);
            //    request.Method = "POST";
            //    request.ContentType = "application/x-www-form-urlencoded";
            //    string postData = d;
            //    byte[] bytes = Encoding.UTF8.GetBytes(postData);
            //    request.ContentLength = bytes.Length;

            //    Stream requestStream = request.GetRequestStream();
            //    requestStream.Write(bytes, 0, bytes.Length);

            //    WebResponse response = request.GetResponse();
            //    Stream stream = response.GetResponseStream();
            //    StreamReader reader = new StreamReader(stream);

            //    var result = reader.ReadToEnd();
            //    stream.Dispose();
            //    reader.Dispose();
            //}
            //catch (Exception e)
            //{
            //    this._log.TrackException(e);
            //    throw;
            //}

            var client = new HttpClient();
            client.BaseAddress = new Uri(_hookUrl);
            var request = new HttpRequestMessage(HttpMethod.Post, "");

            var keyValues = new List<KeyValuePair<string, string>>();
            keyValues.Add(new KeyValuePair<string, string>("NEW_ITEM-DESCRIPTION[0]", orderItems[0].Description));
            keyValues.Add(new KeyValuePair<string, string>("NEW_ITEM-QUANTITY[0]", orderItems[0].Quantity.ToString()));
            keyValues.Add(new KeyValuePair<string, string>("NEW_ITEM-UNIT[0]", orderItems[0].Unit));
            keyValues.Add(new KeyValuePair<string, string>("NEW_ITEM-PRICE[0]", orderItems[0].Price.ToString()));
            keyValues.Add(new KeyValuePair<string, string>("NEW_ITEM-CURRENCY[0]", orderItems[0].Currency));
            keyValues.Add(new KeyValuePair<string, string>("NEW_ITEM-LEADTIME[0]", orderItems[0].LeadTime.ToString()));
            keyValues.Add(new KeyValuePair<string, string>("NEW_ITEM-VENDORMAT[0]", orderItems[0].VendorMat));
            keyValues.Add(new KeyValuePair<string, string>("NEW_ITEM-MATGROUP[0]", orderItems[0].MatGroup));
            

            request.Content = new FormUrlEncodedContent(keyValues);
            var response = await client.SendAsync(request);



        }
    }
}