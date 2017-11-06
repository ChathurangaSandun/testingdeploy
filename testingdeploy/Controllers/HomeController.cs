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

        private string a;
        TelemetryClient _log = new Microsoft.ApplicationInsights.TelemetryClient();
        private static MainRequest request;

        //[HttpPost]
        public ActionResult PunchoutSetupRequest()
        {



            _log.TrackTrace("Ok " + DateTime.Now.ToString());


            var req = Request.InputStream;
            var xml = new StreamReader(req).ReadToEnd();



           _log.TrackTrace(xml.ToString());

            var xmlSerializer = new XmlSerializer(typeof(MainRequest));

            request = (MainRequest)xmlSerializer.Deserialize(new StringReader(xml.ToString()));
            System.Web.HttpContext.Current.Application["BUYER_URL"] = request.Request.PunchOutSetupRequest.BrowserFormPost.URL;


            MainResponse mainResponse = new MainResponse()
            {
                
                PayloadID = request.PayloadID,
                Timestamp = request.Timestamp,
                Response = new Response()
                {
                    Status = new Status()
                    {
                        Code = "200",
                        Text = "success"
                    },
                    PunchOutSetupResponse = new PunchOutSetupResponse()
                    {
                        StartPage = new StartPage()
                        {
                            URL = "https://fffffff.azurewebsites.net/home/index"

                        }
                    }
                }
            };

            var stringwriter = new StringWriter();

            XmlSerializer serializer = new XmlSerializer(typeof(MainResponse));
            
            serializer.Serialize(stringwriter, mainResponse);
            var responseTest = stringwriter.ToString().Replace("utf-16","utf-8");
            var contains = responseTest.Contains("!DOCTYPE");
            if (!contains)
            {
                var indexDoctypePut = responseTest.IndexOf("?>", StringComparison.Ordinal) + 2;
                
                
                var firstPart = responseTest.Substring(0, indexDoctypePut);
                var secondPart = responseTest.Substring(indexDoctypePut, responseTest.Length-indexDoctypePut);
                secondPart =
                    secondPart.Replace(
                        "xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"",
                        "");
                var text = firstPart + "<!DOCTYPE cXML SYSTEM \"http://xml.cxml.org/schemas/cXML/1.2.011/cXML.dtd\">" + secondPart;



                _log.TrackTrace(text);
                return Content(text);
            }
            else
            {
                return Content(responseTest);
            }


            

           
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



        public ActionResult ConfirmPunchout()
        {

            if (request != null)
            {
                OrderMessageCXML cxml = new OrderMessageCXML()
                {
                    PayloadID = request.PayloadID,
                    Lang = request.Lang,
                    Timestamp = request.Timestamp,
                    Header = new OrderMessageHeader()
                    {
                        From = new OrderMessageFrom()
                        {
                            Credential = new OrderMessageCredential()
                            {
                                Domain = "DUNS",
                                Identity = request.Header.From.Credential.Identity,
                            }
                        },
                        To = new OrderMessageTo()
                        {
                            Credential = new OrderMessageCredential()
                            {
                                Domain = "DUNS",
                                Identity = request.Header.To.Credential.Identity

                            },
                        },
                        Sender = new OrderMessageSender()
                        {

                            Credential = new OrderMessageCredential()
                            {
                                Domain = "DUNS",
                                Identity = request.Header.From.Credential.Identity,
                            }
                        }
                    },

                    Message = new Message()
                    {
                        PunchOutOrderMessage = new PunchOutOrderMessage()
                        {
                            BuyerCookie = request.Request.PunchOutSetupRequest.BuyerCookie,
                            PunchOutOrderMessageHeader = new PunchOutOrderMessageHeader()
                            {
                                OperationAllowed = "Create",
                                Total = new Total()
                                {
                                    Money = new Money()
                                    {
                                        Currency = "USD",
                                        Text = "20145.22",
                                    }
                                },

                            },
                            ItemIn = new List<ItemIn>()
                            {
                                new ItemIn()
                                {
                                    Quantity = "1",
                                    ItemID = new ItemID()
                                    {
                                        
                                        SupplierPartID = "dddd"
                                    },
                                    ItemDetail = new ItemDetail()
                                    {
                                        Classification = new Classification()
                                        {
                                            Domain = "UNSPSC",
                                            Text = "22525"
                                        },
                                        Description = new Description()
                                        {
                                            Lang = "en-US",
                                            Text = "belttt"
                                        },
                                        //ManufacturerName = "chathuranga",
                                        ManufacturerPartID = "123455",
                                        UnitOfMeasure = "EA",
                                        UnitPrice = new UnitPrice()
                                        {
                                            Money = new Money()
                                            {
                                                Currency = "USD",
                                                Text = "10.25"
                                            }
                                        }
                                    }
                                }
                            }
                            


                        }
                    }

                };


                var stringwriter = new StringWriter();

                XmlSerializer serializer = new XmlSerializer(typeof(OrderMessageCXML));
                serializer.Serialize(stringwriter, cxml);
                var message = stringwriter.ToString().Replace("utf-16", "utf-8");
                //_log.TrackTrace(message);

                var a = Session["BUYER_URL"];

                System.Web.HttpContext.Current.Application["ORDER_MESSAGE"] = message;
            }

            return View();
        }


    }
}