using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StripeAppPrototype.Dtos
{
    public class Invoice_Settings
    {
        public object custom_fields { get; set; }
        public object default_payment_method { get; set; }
        public object footer { get; set; }
    }
}
