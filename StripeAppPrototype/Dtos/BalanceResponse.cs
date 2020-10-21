using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StripeAppPrototype.Dtos
{

    public class BalanceResponse
    {
        public string _object { get; set; }
        public Available[] available { get; set; }
        public bool livemode { get; set; }
        public Pending[] pending { get; set; }
    }

    public class Available
    {
        public int amount { get; set; }
        public string currency { get; set; }
        public Source_Types source_types { get; set; }
    }

    public class Source_Types
    {
        public int card { get; set; }
    }

    public class Pending
    {
        public int amount { get; set; }
        public string currency { get; set; }
        public Source_Types1 source_types { get; set; }
    }

    public class Source_Types1
    {
        public int card { get; set; }
    }

}
