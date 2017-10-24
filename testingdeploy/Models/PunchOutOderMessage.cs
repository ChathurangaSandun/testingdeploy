using System.Collections.Generic;
using System.Xml.Serialization;

namespace testingdeploy.Models
{
    [XmlRoot(ElementName = "Credential")]
    public class OrderMessageCredential
    {
        [XmlElement(ElementName = "Identity")]
        public string Identity { get; set; }
        [XmlAttribute(AttributeName = "domain")]
        public string Domain { get; set; }
    }

    [XmlRoot(ElementName = "From")]
    public class OrderMessageFrom
    {
        [XmlElement(ElementName = "Credential")]
        public OrderMessageCredential Credential { get; set; }
    }

    [XmlRoot(ElementName = "To")]
    public class OrderMessageTo
    {
        [XmlElement(ElementName = "Credential")]
        public OrderMessageCredential Credential { get; set; }
    }

    [XmlRoot(ElementName = "Sender")]
    public class OrderMessageSender
    {
        [XmlElement(ElementName = "Credential")]
        public OrderMessageCredential Credential { get; set; }
        [XmlElement(ElementName = "UserAgent")]
        public string UserAgent { get; set; }
    }

    [XmlRoot(ElementName = "Header")]
    public class OrderMessageHeader
    {
        [XmlElement(ElementName = "From")]
        public OrderMessageFrom From { get; set; }
        [XmlElement(ElementName = "To")]
        public OrderMessageTo To { get; set; }
        [XmlElement(ElementName = "Sender")]
        public OrderMessageSender Sender { get; set; }
    }

    [XmlRoot(ElementName = "Money")]
    public class Money
    {
        [XmlAttribute(AttributeName = "currency")]
        public string Currency { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "Total")]
    public class Total
    {
        [XmlElement(ElementName = "Money")]
        public Money Money { get; set; }
    }

    [XmlRoot(ElementName = "PunchOutOrderMessageHeader")]
    public class PunchOutOrderMessageHeader
    {
        [XmlElement(ElementName = "Total")]
        public Total Total { get; set; }
        [XmlAttribute(AttributeName = "operationAllowed")]
        public string OperationAllowed { get; set; }
    }

    [XmlRoot(ElementName = "ItemID")]
    public class OrderMessageItemID
    {
        [XmlElement(ElementName = "SupplierPartID")]
        public string SupplierPartID { get; set; }
        [XmlElement(ElementName = "SupplierPartAuxiliaryID")]
        public string SupplierPartAuxiliaryID { get; set; }
    }

    [XmlRoot(ElementName = "UnitPrice")]
    public class UnitPrice
    {
        [XmlElement(ElementName = "Money")]
        public Money Money { get; set; }
    }

    [XmlRoot(ElementName = "Description")]
    public class Description
    {
        [XmlAttribute(AttributeName = "lang", Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string Lang { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "Classification")]
    public class Classification
    {
        [XmlAttribute(AttributeName = "domain")]
        public string Domain { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "Extrinsic")]
    public class OrderMessageExtrinsic
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "ItemDetail")]
    public class ItemDetail
    {
        [XmlElement(ElementName = "UnitPrice")]
        public UnitPrice UnitPrice { get; set; }
        [XmlElement(ElementName = "Description")]
        public Description Description { get; set; }
        [XmlElement(ElementName = "UnitOfMeasure")]
        public string UnitOfMeasure { get; set; }
        [XmlElement(ElementName = "Classification")]
        public Classification Classification { get; set; }
        [XmlElement(ElementName = "ManufacturerPartID")]
        public string ManufacturerPartID { get; set; }
        [XmlElement(ElementName = "ManufacturerName")]
        public string ManufacturerName { get; set; }
        [XmlElement(ElementName = "Extrinsic")]
        public List<OrderMessageExtrinsic> Extrinsic { get; set; }
    }

    [XmlRoot(ElementName = "ItemIn")]
    public class ItemIn
    {
        [XmlElement(ElementName = "ItemID")]
        public ItemID ItemID { get; set; }
        [XmlElement(ElementName = "ItemDetail")]
        public ItemDetail ItemDetail { get; set; }
        [XmlAttribute(AttributeName = "quantity")]
        public string Quantity { get; set; }
    }

    [XmlRoot(ElementName = "PunchOutOrderMessage")]
    public class PunchOutOrderMessage
    {
        [XmlElement(ElementName = "BuyerCookie")]
        public string BuyerCookie { get; set; }
        [XmlElement(ElementName = "PunchOutOrderMessageHeader")]
        public PunchOutOrderMessageHeader PunchOutOrderMessageHeader { get; set; }
        [XmlElement(ElementName = "ItemIn")]
        public List<ItemIn> ItemIn { get; set; }
    }

    [XmlRoot(ElementName = "Message")]
    public class Message
    {
        [XmlElement(ElementName = "PunchOutOrderMessage")]
        public PunchOutOrderMessage PunchOutOrderMessage { get; set; }
    }

    [XmlRoot(ElementName = "cXML")]
    public class OrderMessageCXML
    {
        [XmlElement(ElementName = "Header")]
        public OrderMessageHeader Header { get; set; }
        [XmlElement(ElementName = "Message")]
        public Message Message { get; set; }
        [XmlAttribute(AttributeName = "payloadID")]
        public string PayloadID { get; set; }
        [XmlAttribute(AttributeName = "lang", Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string Lang { get; set; }
        [XmlAttribute(AttributeName = "timestamp")]
        public string Timestamp { get; set; }
    }

}
