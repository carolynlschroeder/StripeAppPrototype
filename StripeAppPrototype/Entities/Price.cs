using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StripeAppPrototype.Entities
{
    public class Price
    {
        [Key]
        [StringLength(50)]
        public string Id { get; set; }
        public decimal Amount { get; set; }
        [StringLength(25)]
        public string Currency { get; set; }
        [StringLength(50)]
        [ForeignKey("Product")]
        public string ProductId { get; set; }
        [StringLength(50)]
        public string Nickname { get; set; }
        public Product Product { get; set; }
    }
}
