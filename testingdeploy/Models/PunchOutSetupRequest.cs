﻿using System.Collections.Generic;
using System.Xml.Serialization;

namespace testingdeploy.Models
{
    [XmlRoot(ElementName = "Credential")]
    public class Credential
    {
        [XmlElement(ElementName = "Identity")]
        public string Identity { get; set; }
        [XmlAttribute(AttributeName = "domain")]
        public string Domain { get; set; }
        [XmlElement(ElementName = "SharedSecret")]
        public string SharedSecret { get; set; }
    }

    [XmlRoot(ElementName = "From")]
    public class From
    {
        [XmlElement(ElementName = "Credential")]
        public Credential Credential { get; set; }
    }

    [XmlRoot(ElementName = "To")]
    public class To
    {
        [XmlElement(ElementName = "Credential")]
        public Credential Credential { get; set; }
    }

    [XmlRoot(ElementName = "Sender")]
    public class Sender
    {
        [XmlElement(ElementName = "Credential")]
        public Credential Credential { get; set; }
        [XmlElement(ElementName = "UserAgent")]
        public string UserAgent { get; set; }
    }

    [XmlRoot(ElementName = "Header")]
    public class Header
    {
        [XmlElement(ElementName = "From")]
        public From From { get; set; }
        [XmlElement(ElementName = "To")]
        public To To { get; set; }
        [XmlElement(ElementName = "Sender")]
        public Sender Sender { get; set; }
    }

    [XmlRoot(ElementName = "Extrinsic")]
    public class Extrinsic
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "BrowserFormPost")]
    public class BrowserFormPost
    {
        [XmlElement(ElementName = "URL")]
        public string URL { get; set; }
    }

    [XmlRoot(ElementName = "SupplierSetup")]
    public class SupplierSetup
    {
        [XmlElement(ElementName = "URL")]
        public string URL { get; set; }
    }

    [XmlRoot(ElementName = "Name")]
    public class Name
    {
        [XmlAttribute(AttributeName = "lang", Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string Lang { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "Address")]
    public class Address
    {
        [XmlElement(ElementName = "Name")]
        public Name Name { get; set; }
        [XmlAttribute(AttributeName = "addressID")]
        public string AddressID { get; set; }
    }

    [XmlRoot(ElementName = "ShipTo")]
    public class ShipTo
    {
        [XmlElement(ElementName = "Address")]
        public Address Address { get; set; }
    }

    [XmlRoot(ElementName = "ItemID")]
    public class ItemID
    {
        [XmlElement(ElementName = "SupplierPartID")]
        public string SupplierPartID { get; set; }
        [XmlElement(ElementName = "SupplierPartAuxiliaryID")]
        public string SupplierPartAuxiliaryID { get; set; }
    }

    [XmlRoot(ElementName = "SelectedItem")]
    public class SelectedItem
    {
        [XmlElement(ElementName = "ItemID")]
        public ItemID ItemID { get; set; }
    }

    [XmlRoot(ElementName = "PunchOutSetupRequest")]
    public class PunchOutSetupRequest
    {
        [XmlElement(ElementName = "BuyerCookie")]
        public string BuyerCookie { get; set; }
        [XmlElement(ElementName = "Extrinsic")]
        public List<Extrinsic> Extrinsic { get; set; }
        [XmlElement(ElementName = "BrowserFormPost")]
        public BrowserFormPost BrowserFormPost { get; set; }
        [XmlElement(ElementName = "SupplierSetup")]
        public SupplierSetup SupplierSetup { get; set; }
        [XmlElement(ElementName = "ShipTo")]
        public ShipTo ShipTo { get; set; }
        [XmlElement(ElementName = "SelectedItem")]
        public SelectedItem SelectedItem { get; set; }
        [XmlAttribute(AttributeName = "operation")]
        public string Operation { get; set; }
    }

    [XmlRoot(ElementName = "Request")]
    public class Request
    {
        [XmlElement(ElementName = "PunchOutSetupRequest")]
        public PunchOutSetupRequest PunchOutSetupRequest { get; set; }
    }

    [XmlRoot(ElementName = "cXML")]
    public class MainRequest
    {
        [XmlElement(ElementName = "Header")]
        public Header Header { get; set; }
        [XmlElement(ElementName = "Request")]
        public Request Request { get; set; }
        [XmlAttribute(AttributeName = "payloadID")]
        public string PayloadID { get; set; }
        [XmlAttribute(AttributeName = "timestamp")]
        public string Timestamp { get; set; }
        [XmlAttribute(AttributeName = "lang", Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string Lang { get; set; }
    }

}
