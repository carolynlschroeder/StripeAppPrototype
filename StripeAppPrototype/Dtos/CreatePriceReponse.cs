using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;

namespace StripeAppPrototype.Dtos
{

    public class CreatePriceResponse
    {
        public string id { get; set; }
        public string _object { get; set; }
        public bool active { get; set; }
        public string billing_scheme { get; set; }
        public int created { get; set; }
        public string currency { get; set; }
        public bool livemode { get; set; }
        public object lookup_key { get; set; }
        public Metadata metadata { get; set; }
        public object nickname { get; set; }
        public string product { get; set; }
        public Recurring recurring { get; set; }
        public object tiers_mode { get; set; }
        public object transform_quantity { get; set; }
        public string type { get; set; }
        public int unit_amount { get; set; }
        public string unit_amount_decimal { get; set; }
    }

}
