using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StripeAppPrototype.Models
{
    public class PaymentMethodModel
    {
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
        public string PaymentMethodId { get; set; }
        public string StripePublishableKey { get; set; }
    }
}
