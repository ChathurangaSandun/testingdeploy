/* 
 Licensed under the Apache License, Version 2.0

 http://www.apache.org/licenses/LICENSE-2.0
 */

using System;
using System.Text;
using System.Xml.Serialization;

namespace testingdeploy.Models
{
    [XmlRoot(ElementName = "Status")]
    public class Status
    {
        [XmlAttribute(AttributeName = "code")]
        public string Code { get; set; }
        [XmlAttribute(AttributeName = "text")]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "StartPage")]
    public class StartPage
    {
        [XmlElement(ElementName = "URL")]
        public string URL { get; set; }
    }

    [XmlRoot(ElementName = "PunchOutSetupResponse")]
    public class PunchOutSetupResponse
    {
        [XmlElement(ElementName = "StartPage")]
        public StartPage StartPage { get; set; }
    }

    [XmlRoot(ElementName = "Response")]
    public class Response
    {
        [XmlElement(ElementName = "Status")]
        public Status Status { get; set; }
        [XmlElement(ElementName = "PunchOutSetupResponse")]
        public PunchOutSetupResponse PunchOutSetupResponse { get; set; }
    }

    [XmlRoot(ElementName = "cXML")]
    public class MainResponse
    {
        [XmlElement(ElementName = "Response")]
        public Response Response { get; set; }
        [XmlAttribute(AttributeName = "payloadID")]
        public string PayloadID { get; set; }
        [XmlAttribute(AttributeName = "timestamp")]
        public string Timestamp { get; set; }
    }




    //public  static class PunchoutResponse
    //{
    //    public static  void GetResponseMessage()
    //    {
    //        string xmlString = "";
            
    //        StringBuilder sb = new StringBuilder();
            
    //        sb.Append("<?xml version = \"1.0\" encoding=\"UTF-8\"?>");
    //        sb.Append("<!DOCTYPE cXML SYSTEM \"http://xml.cXML.org/schemas/cXML/1.2.014/cXML.dtd\">");
    //        sb.Append(string.Format("<cXML payloadID=\"9949496-189@myaspspace.com\" xml:lang=\"en-US\" timestamp=\"{0}-{1}-{2}T{3}:{4}:{5}-08:00\" >", DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, DateTime.Now.Hour, DateTime.Now.Minute, "00"));
    //        sb.Append("<Response>");
            
    //                    if (status)
    //                        {
    //            sb.Append("<Status code=\"200\" text=\"success\"></Status>");
    //            sb.Append("<PunchOutSetupResponse>");
    //            sb.Append("<StartPage>");
    //            sb.Append("<URL>");
    //            sb.Append(pucnoutSessionURL);   //http://xml.workchairs.com/retrieve?reqUrl=20626;Initial=TRUE
    //            sb.Append("</URL>");
    //            sb.Append("</StartPage>");
    //            sb.Append("</PunchOutSetupResponse>");
    //                        }
    //                    else
    //        {
    //            sb.Append("<Status code=\"500\" text=\"Error\">Authentication failure</Status>");
    //                        }
            
            
    //        sb.Append("</Response>");
    //        sb.Append("</cXML>");
    //                    //sb.Append("");
    //                    //sb.Append("");
            
    //        xmlString = sb.ToString();
            
            
    //        //base.XmlDoc.LoadXml(xmlString);
            
            
    //    }

    //}



}
