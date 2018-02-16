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
            return this.View("CartPage");
        }

        public ActionResult PunchoutHookOci()
        {
                List<OciOrderItem> orderItems = new List<OciOrderItem>();
                orderItems.Add(new OciOrderItem()
                {
                    Description = "Item 1",
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
                    Description = "Item 2",
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
                    d += @"NEW_ITEM-DESCRIPTION["+i+"]="+item.Description;
                    d += @"&NEW_ITEM-QUANTITY[" + i+"]="+item.Quantity;
                    d += @"&NEW_ITEM-UNIT[" + i+"]="+item.Unit;
                    d += @"&NEW_ITEM-PRICE[" + i+"]="+item.Price;
                    d += @"&NEW_ITEM-CURRENCY[" + i+"]="+item.Currency;
                    d += @"&NEW_ITEM-LEADTIME[" + i+"]="+item.LeadTime;
                    d += @"&NEW_ITEM-VENDORMAT[" + i+"]="+item.VendorMat;
                    d += @"&NEW_ITEM-MATGROUP[" + i+"]="+item.MatGroup;
                    //itemDetailsDictionary.Add(itemNames[0].Replace("n", i.ToString()), item.Description);
                    //itemDetailsDictionary.Add(itemNames[1].Replace("n", i.ToString()), item.Quantity);
                    //itemDetailsDictionary.Add(itemNames[2].Replace("n", i.ToString()), item.Unit);
                    //itemDetailsDictionary.Add(itemNames[3].Replace("n", i.ToString()), item.Price);
                    //itemDetailsDictionary.Add(itemNames[4].Replace("n", i.ToString()), item.Currency);
                    //itemDetailsDictionary.Add(itemNames[5].Replace("n", i.ToString()), item.LeadTime);
                    //itemDetailsDictionary.Add(itemNames[6].Replace("n", i.ToString()), item.VendorMat);
                    //itemDetailsDictionary.Add(itemNames[7].Replace("n", i.ToString()), item.MatGroup);
                    i++;
                }
            
            this._log.TrackTrace(d);
            byte[] data = encoding.GetBytes(d);
      
   

            PostDataOfItem(d);


            return this.View();
        }

        private void PostDataOfItem(string d)
        {
            // Create a request using a URL that can receive a post.   
            WebRequest request = WebRequest.Create(_hookUrl);
            // Set the Method property of the request to POST.  
            request.Method = "POST";
            // Create POST data and convert it to a byte array.  
            string postData = d;
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            // Set the ContentType property of the WebRequest.  
            request.ContentType = "application/form-data";
            // Set the ContentLength property of the WebRequest.  
            request.ContentLength = byteArray.Length;
            // Get the request stream.  
            Stream dataStream = request.GetRequestStream();
            // Write the data to the request stream.  
            dataStream.Write(byteArray, 0, byteArray.Length);
            // Close the Stream object.  
            dataStream.Close();
            // Get the response.  
            WebResponse response = request.GetResponse();
            // Display the status.  
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);
            // Get the stream containing content returned by the server.  
            dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.  
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.  
            string responseFromServer = reader.ReadToEnd();
            // Display the content.  
            Console.WriteLine(responseFromServer);
            // Clean up the streams.  
            reader.Close();
            dataStream.Close();
            response.Close();

            //HttpWebRequest myRequest =
            //    (HttpWebRequest)WebRequest.Create(_hookUrl);
            //myRequest.Method = "POST";
            //myRequest.ContentType = "application/x-www-form-urlencoded";
            //myRequest.ContentLength = data.Length;
            //Stream newStream = myRequest.GetRequestStream();
            //newStream.Write(data, 0, data.Length);
            //newStream.Close();
        }
    }
}