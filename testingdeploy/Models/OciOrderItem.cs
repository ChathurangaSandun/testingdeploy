using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace testingdeploy.Models
{
    public class OciOrderItem
    {
        public string Description { get; set; }
        public double Quantity{ get; set; }
        public string  Unit { get; set; }
        public double Price { get; set; }
        public string Currency { get; set; }

        public int LeadTime { get; set; }
        public string VendorMat { get; set; }
        public string  MatGroup { get; set; }
    }
}