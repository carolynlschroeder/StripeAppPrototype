using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StripeAppPrototype.Entities
{
    public class Invoice
    {
        [Key]
        [StringLength(50)]
        public string Id { get; set; }
        [ForeignKey("Customer")]
        public string CustomerId { get; set; }

        public Customer Customer { get; set; }
    }
}
