using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StripeAppPrototype.Dtos
{

    public class DetachPaymentMethodResponse
    {
        public string id { get; set; }
        public string _object { get; set; }
        public Billing_Details billing_details { get; set; }
        public Card card { get; set; }
        public int created { get; set; }
        public object customer { get; set; }
        public bool livemode { get; set; }
        public Metadata metadata { get; set; }
        public string type { get; set; }
    }


}
