using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StripeAppPrototype.Dtos
{
    public class Recurring
    {
        public object aggregate_usage { get; set; }
        public string interval { get; set; }
        public int interval_count { get; set; }
        public string usage_type { get; set; }
    }
}
