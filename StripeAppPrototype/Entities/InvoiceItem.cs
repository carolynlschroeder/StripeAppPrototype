using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StripeAppPrototype.Entities
{
    public class InvoiceItem
    {
        [Key]
        [StringLength(50)]
        public string Id { get; set; }
        [ForeignKey("Customer")]
        public string CustomerId { get; set; }
        [ForeignKey("Price")]
        public string PriceId { get; set; }
        public Customer Customer { get; set; }
        public Price Price { get; set; }
    }
}
