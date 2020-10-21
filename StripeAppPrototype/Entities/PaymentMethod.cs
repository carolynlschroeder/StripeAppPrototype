using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StripeAppPrototype.Entities
{
    public class PaymentMethod
    {
        [Key]
        [StringLength(50)]
        public string Id { get; set; }
        [StringLength(50)]
        [ForeignKey("Customer")]
        public string CustomerId { get; set; }
        [StringLength(150)]
        public string Description { get; set; }
        public bool IsPrimary { get; set; }
        public Customer Customer { get; set; }
    }
}
