using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace testingdeploy.Controllers
{
    using System.Globalization;

    using Microsoft.Ajax.Utilities;
    using Microsoft.ApplicationInsights;

    using testingdeploy.Models;

    public class PunchOutOciController : Controller
    {

        private string _hookUrl;

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
            if (!this._hookUrl.IsNullOrWhiteSpace())
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

                int i = 1;
                foreach (var item in orderItems)
                {
                    itemDetailsDictionary.Add(itemNames[0].Replace("n", i.ToString()), item.Description);
                    itemDetailsDictionary.Add(itemNames[1].Replace("n", i.ToString()), item.Quantity.ToString(CultureInfo.InvariantCulture));
                    itemDetailsDictionary.Add(itemNames[2].Replace("n", i.ToString()), item.Unit);
                    itemDetailsDictionary.Add(itemNames[3].Replace("n", i.ToString()), item);
                    itemDetailsDictionary.Add(itemNames[4].Replace("n", i.ToString()), item);
                    itemDetailsDictionary.Add(itemNames[5].Replace("n", i.ToString()), item);
                    itemDetailsDictionary.Add(itemNames[6].Replace("n", i.ToString()), item);
                    itemDetailsDictionary.Add(itemNames[7].Replace("n", i.ToString()), item);
                    itemDetailsDictionary.Add(itemNames[8].Replace("n", i.ToString()), item);
                    itemDetailsDictionary.Add(itemNames[9].Replace("n", i.ToString()), item);

                }

                //for (int i = 0; i < orderItems.Count;  i++)
                //{
                //   itemDetailsDictionary.Add(itemNames[0].Replace("n", (i+1).ToString()),orderItems[i]); 

                //}




            }
            return this.View();
        }
    }
}