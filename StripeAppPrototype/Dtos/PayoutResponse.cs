using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StripeAppPrototype.Dtos
{

    public class PayoutResponse
    {
        public string id { get; set; }
        public string _object { get; set; }
        public int amount { get; set; }
        public int arrival_date { get; set; }
        public bool automatic { get; set; }
        public string balance_transaction { get; set; }
        public int created { get; set; }
        public string currency { get; set; }
        public string description { get; set; }
        public string destination { get; set; }
        public object failure_balance_transaction { get; set; }
        public object failure_code { get; set; }
        public object failure_message { get; set; }
        public bool livemode { get; set; }
        public Metadata metadata { get; set; }
        public string method { get; set; }
        public object original_payout { get; set; }
        public object reversed_by { get; set; }
        public string source_type { get; set; }
        public object statement_descriptor { get; set; }
        public string status { get; set; }
        public string type { get; set; }
    }

}
