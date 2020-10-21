using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;

namespace StripeAppPrototype.Dtos
{

    public class CreateProductResponse
    {
        public string id { get; set; }
        public string _object { get; set; }
        public bool active { get; set; }
        public object[] attributes { get; set; }
        public int created { get; set; }
        public object description { get; set; }
        public object[] images { get; set; }
        public bool livemode { get; set; }
        public Metadata metadata { get; set; }
        public string name { get; set; }
        public object statement_descriptor { get; set; }
        public object unit_label { get; set; }
        public int updated { get; set; }
    }

}
