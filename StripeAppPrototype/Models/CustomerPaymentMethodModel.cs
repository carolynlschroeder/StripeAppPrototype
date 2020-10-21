using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StripeAppPrototype.Models
{
    public class CustomerPaymentMethodModel
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string StripeToken { get; set; }
    }
}
