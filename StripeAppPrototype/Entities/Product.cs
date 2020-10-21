using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StripeAppPrototype.Entities
{
    public class Product
    {
        [Key]
        [StringLength(50)]
        public string Id { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
    }
}
