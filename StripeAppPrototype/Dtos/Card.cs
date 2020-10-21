using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StripeAppPrototype.Dtos
{
    public class Card
    {
        public string brand { get; set; }
        public Checks checks { get; set; }
        public string country { get; set; }
        public int exp_month { get; set; }
        public int exp_year { get; set; }
        public string fingerprint { get; set; }
        public string funding { get; set; }
        public object generated_from { get; set; }
        public string last4 { get; set; }
        public Networks networks { get; set; }
        public Three_D_Secure_Usage three_d_secure_usage { get; set; }
        public object wallet { get; set; }
    }
}
