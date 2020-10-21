using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace StripeAppPrototype.Entities
{
    public class Customer
    {
        [Key]
        [StringLength(50)]
        public string Id { get; set; }
        [StringLength(100)]
        public string Email { get; set; }
    }
}
