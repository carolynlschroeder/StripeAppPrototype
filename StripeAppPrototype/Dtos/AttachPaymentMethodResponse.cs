using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StripeAppPrototype.Dtos
{

    public class AttachPaymentMethodResponse
    {
        public string id { get; set; }
        public string _object { get; set; }
        public Billing_Details billing_details { get; set; }
        public Card card { get; set; }
        public int created { get; set; }
        public string customer { get; set; }
        public bool livemode { get; set; }
        public Metadata metadata { get; set; }
        public string type { get; set; }
    }

    public class Billing_Details
    {
        public Address address { get; set; }
        public object email { get; set; }
        public object name { get; set; }
        public object phone { get; set; }
    }

    public class Address
    {
        public object city { get; set; }
        public object country { get; set; }
        public object line1 { get; set; }
        public object line2 { get; set; }
        public object postal_code { get; set; }
        public object state { get; set; }
    }

 

    public class Checks
    {
        public object address_line1_check { get; set; }
        public object address_postal_code_check { get; set; }
        public string cvc_check { get; set; }
    }

    public class Networks
    {
        public string[] available { get; set; }
        public object preferred { get; set; }
    }

    public class Three_D_Secure_Usage
    {
        public bool supported { get; set; }
    }


}
